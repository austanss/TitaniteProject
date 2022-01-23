
namespace TitaniteProject.Toolchain;

internal class SourceFile
{
    public SourceFile(string filename, SourceLanguage language)
    {
        FileName = filename;
        Language = language;
        Stream = File.OpenRead(filename);
    }

    public readonly string FileName;
    public readonly SourceLanguage Language;
    public readonly FileStream Stream;
}
