
namespace TitaniteProject.Toolchain.Backend;

internal record struct TabledString
{
    public TabledString(ulong index, string value)
    {
        Index = index;
        Value = value;
    }

    public ulong Index { get; init; }
    public string Value { get; init; }

    public bool Equals(TabledString other)
    {
        return Value == other.Value;
    }

    public override int GetHashCode()
    {
        return Value.Length ^ (int)Index;
    }
}
