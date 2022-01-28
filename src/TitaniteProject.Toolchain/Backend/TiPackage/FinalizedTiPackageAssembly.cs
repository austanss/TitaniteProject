
namespace TitaniteProject.Toolchain.Backend.TiPackage;

internal class FinalizedTiPackageAssembly
{
    public FinalizedTiPackageAssembly(UnfinalizedAssembly assembly)
    {
        Data = new();
        FileName = assembly.Name;
        Finalize(assembly);
    }

    private void Finalize(UnfinalizedAssembly assembly)
    {
        ulong[] codeOffsets = CalculateCodeOffsets(assembly);

        TiPackageString[] strings = IntegrateStringTables(assembly, out int[] stringOffsets);
        TiPackageSymbol[] symbols = IntegrateSymbolTables(assembly, codeOffsets, out int[] symbolOffsets);
        TranslatedInstruction[] code = IntegrateCode(assembly, symbolOffsets, stringOffsets);

        TiPackageHeader header = GenerateHeader(code, symbols, strings);

        BinaryWriter finalizer = new(Data);

        finalizer.Write(header.Magic);
        finalizer.Write(header.CodeOffset);
        finalizer.Write(header.SymbolTableOffset);
        finalizer.Write(header.StringTableOffset);
        finalizer.Write(header.ProgramManifestOffset);

        _ = finalizer.Seek((int)header.CodeOffset, SeekOrigin.Begin);

        foreach (TranslatedInstruction instruction in code)
        {
            finalizer.Write(instruction.Opcode);
            foreach (ulong operand in instruction.Operands)
                finalizer.Write(operand);
        }

        _ = finalizer.Seek((int)header.SymbolTableOffset, SeekOrigin.Begin);

        finalizer.Write((ulong)symbols.Length);

        foreach (TiPackageSymbol symbol in symbols)
        {
            finalizer.Write(symbol.Identifier);
            finalizer.Write(symbol.FileOffset);
        }

        _ = finalizer.Seek((int)header.StringTableOffset, SeekOrigin.Begin);

        finalizer.Write((ulong)strings.Length);

        foreach (TiPackageString @string in strings)
        {
            finalizer.Write(@string.Value);
            finalizer.Write(@string.Index);
        }

        _ = finalizer.Seek((int)header.ProgramManifestOffset, SeekOrigin.Begin);

        finalizer.Write(assembly.Manifest.Content);

        finalizer.Flush();
    }

    private TiPackageString[] IntegrateStringTables(UnfinalizedAssembly assembly, out int[] offsets)
    {
        offsets = new int[assembly.Objects.Length];

        List<TiPackageString> table = new();

        foreach ((ParsedSource @object, int i) in assembly.Objects.WithIndex())
        {
            offsets[i] = table.Count;
            foreach ((TiPackageString @string, int j) in @object.Strings.WithIndex())
                table.Add(new TiPackageString((ulong)offsets[i] + (ulong)j, @string.Value));
        }

        return table.ToArray();
    }

    private TiPackageSymbol[] IntegrateSymbolTables(UnfinalizedAssembly assembly, ulong[] codeOffsets, out int[] offsets)
    {
        offsets = new int[assembly.Objects.Length];

        List<TiPackageSymbol> table = new();

        foreach ((ParsedSource @object, int i) in assembly.Objects.WithIndex())
        {
            offsets[i] = table.Count;
            foreach (TiPackageSymbol @symbol in @object.Symbols)
                table.Add(new TiPackageSymbol(symbol.Identifier, codeOffsets[i] + symbol.FileOffset));
        }

        return table.ToArray();
    }

    private TranslatedInstruction[] IntegrateCode(UnfinalizedAssembly assembly, int[] symbolOffsets, int[] stringOffsets)
    {
        List<TranslatedInstruction> code = new();

        foreach ((ParsedSource @object, int i) in assembly.Objects.WithIndex())
        {
            foreach (TranslatedInstruction @instruction in @object.Instructions)
            {
                byte opcode = instruction.Opcode;
                ulong[] operands = new ulong[2];

                Array.Copy(instruction.Operands, operands, 2);

                if (opcode == (byte)InstructionOpcode.Jump)
                    operands[0] = operands[0] + (ulong)symbolOffsets[i];

                if (opcode == BackendData.PACKAGE_STRING_OPCODE)
                {
                    opcode = (byte)InstructionOpcode.Set;
                    operands[1] = operands[1] + (ulong)stringOffsets[i];
                }

                code.Add(new TranslatedInstruction(opcode, operands));
            }
        }

        return code.ToArray();
    }

    private TiPackageHeader GenerateHeader(TranslatedInstruction[] instructions, TiPackageSymbol[] symbols, TiPackageString[] strings)
    {
        ulong offset = BackendData.PACKAGE_HEADER_SIZE;

        foreach (TranslatedInstruction instruction in instructions)
            offset += sizeof(byte) + ((ulong)instruction.Operands.Length * sizeof(ulong));

        ulong symbolsOffset = 8 * (offset / 8 + 1);

        foreach (TiPackageSymbol symbol in symbols)
            offset += sizeof(int) + (ulong)symbol.Identifier.Length + sizeof(ulong);

        ulong stringsOffset = 8 * ((offset + sizeof(ulong)) / 8 + 1);

        foreach (TiPackageString @string in strings)
            offset += sizeof(int) + (ulong)@string.Value.Length + sizeof(ulong);

        ulong manifestOffset = 8 * ((offset + sizeof(ulong)) / 8 + 1);

        TiPackageHeader header = new()
        {
            SymbolTableOffset = symbolsOffset,
            StringTableOffset = stringsOffset,
            ProgramManifestOffset = manifestOffset
        };

        return header;
    }

    private ulong[] CalculateCodeOffsets(UnfinalizedAssembly assembly)
    {
        ulong[] offsets = new ulong[assembly.Objects.Length];
        offsets[0] = uint.MinValue;

        foreach ((ParsedSource @object, int i) in assembly.Objects.WithIndex())
        {
            if (i == 0) continue;
            offsets[i] = offsets[i - 1];
            foreach (TranslatedInstruction instruction in @object.Instructions)
                offsets[i] += 1 + ((ulong)instruction.Operands.Length * 8);
        }

        return offsets;
    }

    public readonly string FileName;

    public readonly MemoryStream Data;
}
