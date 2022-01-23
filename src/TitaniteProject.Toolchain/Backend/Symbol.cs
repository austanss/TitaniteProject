
namespace TitaniteProject.Toolchain.Backend;

internal record struct Symbol
{
    public Symbol(string identifier, ulong offset)
    {
        Identifier = identifier;
        FileOffset = offset;
    }

    public string Identifier { get; init; }
    public ulong FileOffset { get; init; }
}
