
namespace TitaniteProject.Toolchain;

internal class UnfinalizedAssembly
{
    public UnfinalizedAssembly(string name, AssemblyFormat format, SourceFile[] sources)
    {
        Name = name;
        Format = format;
        Sources = sources;
        Objects = Array.Empty<ObjectFile>();
    }

    public readonly string Name;
    public readonly AssemblyFormat Format;
    public readonly SourceFile[] Sources;
    public ObjectFile[] Objects;
}
