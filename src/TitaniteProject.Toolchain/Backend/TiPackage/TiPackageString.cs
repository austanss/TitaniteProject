
namespace TitaniteProject.Toolchain.Backend.TiPackage;

internal record struct TiPackageString
{
    public TiPackageString(ulong index, string value)
    {
        Index = index;
        Value = value;
    }

    public ulong Index { get; init; }
    public string Value { get; init; }

    public bool Equals(TiPackageString other)
    {
        return Value == other.Value;
    }

    public override int GetHashCode()
    {
        return Value.Length ^ (int)Index;
    }
}
