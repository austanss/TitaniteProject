
namespace TitaniteProject.Toolchain.Backend.TiPackage;

internal record struct TiPackageSymbol
{
    public TiPackageSymbol(string identifier, ulong offset)
    {
        Identifier = identifier;
        FileOffset = offset;
    }

    public string Identifier { get; init; }
    public ulong FileOffset { get; init; }

    public bool Equals(TiPackageSymbol other)
    {
        return Identifier == other.Identifier;
    }

    public override int GetHashCode()
    {
        return Identifier.Length ^ (int)FileOffset;
    }
}
