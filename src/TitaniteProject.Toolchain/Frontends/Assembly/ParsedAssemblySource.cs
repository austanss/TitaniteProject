﻿
namespace TitaniteProject.Toolchain.Frontends.Assembly;

internal record class ParsedAssemblySource : ParsedSource
{

    public ParsedAssemblySource(SourceFile source)
    {
        List<TranslatedInstruction> instructions = new();
        List<Symbol> symbols = new();
        List<TabledString> strings = new();

        Parse(source, instructions, symbols, strings);

        Instructions = instructions.ToArray();
        Symbols = symbols.ToArray();
        Strings = strings.ToArray();
    }

    private void Parse(SourceFile source, in List<TranslatedInstruction> instructions, in List<Symbol> symbols, in List<TabledString> strings)
    {
        StreamReader reader = new(source.Stream);

        string? line;

        ulong offset = 0;

        while ((line = reader.ReadLine()) != null)
        {
            string instruction = line.Trim();

            if (instruction.StartsWith(';') || instruction == "")
                continue;

            string mnemonic = instruction.Split(' ')[0];

            if (mnemonic == AssemblerData.FUNCTION_MNEMONIC)
            {
                symbols.Add(new(instruction.Remove(0, 4).Trim()[..^1], offset));
                continue;
            }

            string[] parameters = new string[2]; 

            parameters[0] = instruction.Remove(0, 3).Trim().Split(',')[0];

            try
            {
                parameters[1] = instruction.Trim().Remove(0, 4 + parameters[0].Length + 1).Trim();
            }
            catch (ArgumentOutOfRangeException)
            {
                parameters[1] = AssemblerData.NULL_PARAMETER;
            }

            for (int i = 0; i < parameters.Length; i++)
            { 
                parameters[i] = parameters[i].Trim();
                if (parameters[i] == "")
                    parameters[i] = AssemblerData.NULL_PARAMETER;
            }

            byte opcode = AssemblerData.TranslationTable[mnemonic];

            ulong[] operands = new ulong[parameters.Length];

            foreach ((string parameter, int i) in parameters.WithIndex())
            {
                if (opcode == (byte)InstructionOpcode.Call)
                {
                    operands[0] = (ulong)symbols.IndexOf(new Symbol(parameter, 0));
                }
                else if (parameter == AssemblerData.NULL_PARAMETER) operands[i] = 0;
                else if (!ulong.TryParse(parameter, out _))
                {
                    if (strings.Contains(new TabledString(0, parameter)))
                        operands[i] = strings[strings.IndexOf(new TabledString(0, parameter))].Index;
                    else
                    {
                        strings.Add(new((ulong)strings.Count, parameter));
                        operands[i] = strings[^1].Index;
                    }
                }
                else operands[i] = ulong.Parse(parameter);
            }

            instructions.Add(new(opcode, operands));
            offset += 1 + ((ulong)operands.Length * 8);
        }
    }

    public ObjectHeader GenerateHeader()
    {
        ulong offset = BackendData.PACKAGE_HEADER_SIZE;

        foreach (TranslatedInstruction instruction in Instructions)
            offset += sizeof(byte) + ((ulong)instruction.Operands.Length * sizeof(ulong));

        ulong symbolsOffset = offset;

        foreach (Symbol symbol in Symbols)
            offset += sizeof(int) + (ulong)symbol.Identifier.Length + sizeof(ulong);

        ulong stringsOffset = offset;

        foreach (TabledString @string in Strings)
            offset += sizeof(int) + (ulong)@string.Value.Length + sizeof(ulong);

        ObjectHeader header = new()
        {
            SymbolTableOffset = symbolsOffset,
            StringTableOffset = stringsOffset
        };

        return header;
    }

    public override TranslatedInstruction[] Instructions { get; protected set; }
    public override Symbol[] Symbols { get; protected set; }
    public override TabledString[] Strings { get; protected set; }
}
