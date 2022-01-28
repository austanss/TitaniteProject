
namespace TitaniteProject.Commons
{
    internal struct PackageString
    {
        public PackageString(ulong index, string value)
        {
            Index = index;
            Value = value;
        }

        public ulong Index { get; set; }
        public string Value { get; set; }

        public bool Equals(PackageString other)
        {
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.Length ^ (int)Index;
        }
    }
}