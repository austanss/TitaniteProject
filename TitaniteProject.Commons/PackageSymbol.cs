
namespace TitaniteProject.Commons
{
    internal struct PackageSymbol
    {
        public PackageSymbol(string identifier, ulong offset)
        {
            Identifier = identifier;
            FileOffset = offset;
        }

        public string Identifier { get; set; }
        public ulong FileOffset { get; set; }

        public bool Equals(PackageSymbol other)
        {
            return Identifier == other.Identifier;
        }

        public override int GetHashCode()
        {
            return Identifier.Length ^ (int)FileOffset;
        }
    }
}