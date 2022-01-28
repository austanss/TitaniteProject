
namespace TitaniteProject.Toolchain.Backend;

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

        PackageString[] strings = IntegrateStringTables(assembly, out int[] stringOffsets);
        PackageSymbol[] symbols = IntegrateSymbolTables(assembly, codeOffsets, out int[] symbolOffsets);
        InstructionData[] code = IntegrateCode(assembly, symbolOffsets, stringOffsets);

        PackageHeader header = GenerateHeader(code, symbols, strings);

        BinaryWriter finalizer = new(Data);

        finalizer.Write(header.Magic);
        finalizer.Write(header.CodeOffset);
        finalizer.Write(header.SymbolTableOffset);
        finalizer.Write(header.StringTableOffset);
        finalizer.Write(header.ProgramManifestOffset);

        _ = finalizer.Seek((int)header.CodeOffset, SeekOrigin.Begin);

        foreach (InstructionData instruction in code)
        {
            finalizer.Write(instruction.Opcode);
            finalizer.Write(instruction.Operands.Left);
            finalizer.Write(instruction.Operands.Right);
        }

        _ = finalizer.Seek((int)header.SymbolTableOffset, SeekOrigin.Begin);

        finalizer.Write((ulong)symbols.Length);

        foreach (PackageSymbol symbol in symbols)
        {
            finalizer.Write(symbol.Identifier);
            finalizer.Write(symbol.FileOffset);
        }

        _ = finalizer.Seek((int)header.StringTableOffset, SeekOrigin.Begin);

        finalizer.Write((ulong)strings.Length);

        foreach (PackageString @string in strings)
        {
            finalizer.Write(@string.Value);
            finalizer.Write(@string.Index);
        }

        _ = finalizer.Seek((int)header.ProgramManifestOffset, SeekOrigin.Begin);

        finalizer.Write(assembly.Manifest.Content);

        finalizer.Flush();
    }

    private PackageString[] IntegrateStringTables(UnfinalizedAssembly assembly, out int[] offsets)
    {
        offsets = new int[assembly.Objects.Length];

        List<PackageString> table = new();

        foreach ((ParsedSource @object, int i) in assembly.Objects.WithIndex())
        {
            offsets[i] = table.Count;
            foreach ((PackageString @string, int j) in @object.Strings.WithIndex())
                table.Add(new PackageString((ulong)offsets[i] + (ulong)j, @string.Value));
        }

        return table.ToArray();
    }

    private PackageSymbol[] IntegrateSymbolTables(UnfinalizedAssembly assembly, ulong[] codeOffsets, out int[] offsets)
    {
        offsets = new int[assembly.Objects.Length];

        List<PackageSymbol> table = new();

        foreach ((ParsedSource @object, int i) in assembly.Objects.WithIndex())
        {
            offsets[i] = table.Count;
            foreach (PackageSymbol @symbol in @object.Symbols)
                table.Add(new PackageSymbol(symbol.Identifier, codeOffsets[i] + symbol.FileOffset));
        }

        return table.ToArray();
    }

    private InstructionData[] IntegrateCode(UnfinalizedAssembly assembly, int[] symbolOffsets, int[] stringOffsets)
    {
        List<InstructionData> code = new();

        foreach ((ParsedSource @object, int i) in assembly.Objects.WithIndex())
        {
            foreach (InstructionData @instruction in @object.Instructions)
            {
                byte opcode = instruction.Opcode;
                ulong[] operands = new ulong[2];

                operands[0] = instruction.Operands[0];
                operands[1] = instruction.Operands[1];

                if (opcode == (byte)InstructionOpcode.Jump)
                    operands[0] = operands[0] + (ulong)symbolOffsets[i];

                if (opcode == BackendData.PACKAGE_STRING_OPCODE)
                {
                    opcode = (byte)InstructionOpcode.Move;
                    operands[1] = operands[1] + (ulong)stringOffsets[i];
                }

                code.Add(new InstructionData(opcode, 0, new OperandPair(operands[0], operands[1])));
            }
        }

        return code.ToArray();
    }

    private PackageHeader GenerateHeader(InstructionData[] instructions, PackageSymbol[] symbols, PackageString[] strings)
    {
        ulong offset = BackendData.PACKAGE_HEADER_SIZE;

        foreach (InstructionData instruction in instructions)
            offset += sizeof(byte) + ((ulong)2 * sizeof(ulong));

        ulong symbolsOffset = 8 * (offset / 8 + 1);

        foreach (PackageSymbol symbol in symbols)
            offset += sizeof(int) + (ulong)symbol.Identifier.Length + sizeof(ulong);

        ulong stringsOffset = 8 * ((offset + sizeof(ulong)) / 8 + 1);

        foreach (PackageString @string in strings)
            offset += sizeof(int) + (ulong)@string.Value.Length + sizeof(ulong);

        ulong manifestOffset = 8 * ((offset + sizeof(ulong)) / 8 + 1);

        PackageHeader header = new()
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
            foreach (InstructionData _ in @object.Instructions)
                offsets[i] += 1 + ((ulong)2 * 8);
        }

        return offsets;
    }

    public readonly string FileName;

    public readonly MemoryStream Data;
}