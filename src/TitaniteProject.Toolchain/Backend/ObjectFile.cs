
namespace TitaniteProject.Toolchain.Backend;

internal class ObjectFile
{
    public ObjectFile(string identifier)
    {
        Identifier = identifier;
        Content = new MemoryStream();
    }

    public readonly string Identifier;
    public readonly MemoryStream Content;
}
