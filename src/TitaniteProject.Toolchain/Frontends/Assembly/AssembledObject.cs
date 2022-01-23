
namespace TitaniteProject.Toolchain.Frontends.Assembly;

internal class AssembledObject
{
    public AssembledObject(string identifier, SourceFile source)
    {
        Object = new ObjectFile(identifier);
        Assemble(source);
    }

    private void Assemble(SourceFile source)
    {
        ParsedAssemblySource code = new(source);

        ObjectHeader header = code.GenerateHeader();

        BinaryWriter generator = new(Object.Content);

        generator.Write(header.Magic);
        generator.Write(header.CodeOffset);
        generator.Write(header.SymbolTableOffset);
        generator.Write(header.StringTableOffset);

        foreach (TranslatedInstruction instruction in code.Instructions)
        {
            generator.Write(instruction.Opcode);
            foreach (ulong operand in instruction.Operands)
            {
                if (Object.Content.Length + sizeof(ulong) >= Object.Content.Capacity)
                    Object.Content.Capacity += 512;

                generator.Write(operand);
            }
        }

        foreach (Symbol symbol in code.Symbols)
        {
            if (Object.Content.Length + (symbol.Identifier.Length * 2) + 4 >= Object.Content.Capacity)
                Object.Content.SetLength(Object.Content.Capacity + 512);

            generator.Write(symbol.Identifier);

            if (Object.Content.Length + sizeof(ulong) >= Object.Content.Capacity)
                Object.Content.SetLength(Object.Content.Capacity + 512);

            generator.Write(symbol.FileOffset);
        }

        foreach (TabledString @string in code.Strings)
        {
            if (Object.Content.Length + (@string.Value.Length * 2) + 4 >= Object.Content.Capacity)
                Object.Content.SetLength(Object.Content.Capacity + 512);

            generator.Write(@string.Value);

            if (Object.Content.Length + sizeof(ulong) >= Object.Content.Capacity)
                Object.Content.SetLength(Object.Content.Capacity + 512);

            generator.Write(@string.Index);
        }

        generator.Flush();
    }

    public ObjectFile Object { get; }
}
