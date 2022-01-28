
namespace TitaniteProject.Toolchain;

internal class UnfinalizedAssembly
{
    public UnfinalizedAssembly(string name, AssemblyFormat format, SourceFile[] sources, ProgramManifest manifest)
    {
        Name = name;
        Format = format;
        Sources = sources;
        Objects = Array.Empty<ParsedSource?>();
        Manifest = manifest;
    }

    public readonly string Name;
    public readonly AssemblyFormat Format;
    public readonly SourceFile[] Sources;
    public readonly ProgramManifest Manifest;
    public ParsedSource?[] Objects;
}
