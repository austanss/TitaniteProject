
namespace TitaniteProject.Commons
{
    internal struct PackageHeader
    {
        public ulong Magic => 0x717A917E;

        public ulong CodeOffset => sizeof(ulong) * 5;

        public ulong SymbolTableOffset { get; set; }

        public ulong StringTableOffset { get; set; }

        public ulong ProgramManifestOffset { get; set; }
    }
}
