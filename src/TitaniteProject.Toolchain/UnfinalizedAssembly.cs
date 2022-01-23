
namespace TitaniteProject.Toolchain;

internal class UnfinalizedAssembly
{
    public UnfinalizedAssembly(string name, AssemblyFormat format, SourceFile[] sources)
    {
        Name = name;
        Format = format;
        Sources = sources;
        Objects = Array.Empty<ParsedSource?>();
    }

    public readonly string Name;
    public readonly AssemblyFormat Format;
    public readonly SourceFile[] Sources;
    public ParsedSource?[] Objects;
}
