
namespace TitaniteProject.Toolchain;

internal class OutputAssembly
{
    public OutputAssembly(string name, AssemblyFormat format, SourceFile[] sources)
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
