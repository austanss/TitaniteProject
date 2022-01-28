#define TPK_ONLY

namespace TitaniteProject.Toolchain.Interface;

internal class CompilationContext
{
    public CompilationContext(string[] args)
    {
        List<SourceFile> sources = new();
        AssemblyFormat format = AssemblyFormat.Dll;
        ProgramManifest? manifest = null;
        string? output = null;

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i].Trim() == "-s")
            {
                string[] files = args[i + 1].Split(',');

                foreach (string file in files)
                {
                    string extension = file.Split('.')[^1];

                    SourceLanguage language = extension switch
                    {
                        "s" => SourceLanguage.Assembly,
                        "ti" => SourceLanguage.Ti,
                        _ => SourceLanguage.Undetected,
                    };

                    sources.Add(new(file, language));
                }
            }

            if (args[i].Trim() == "-m")
                manifest = new(args[i + 1]);

            if (args[i].Trim() == "-o")
            {
                string specifier = args[i + 1].Split(':')[0];

                format = specifier switch
                {
                    "Win" => AssemblyFormat.Pe,
                    "Linux" => AssemblyFormat.Elf,
                    "Dll" => AssemblyFormat.Dll,
                    "Package" => AssemblyFormat.TiPackage,
                    _ => AssemblyFormat.Object
                };

                output = format == AssemblyFormat.Object ? specifier : args[i + 1].Split(':')[1];
            }

            if (args[i].Trim() == "--disable-finalization")
                DisableFinalization = true;
        }

        if (manifest == null)
            manifest = new(null);

        Sources = sources.ToArray();

        if (output == null)
            output = Sources[0].FileName + ".dll";

#if TPK_ONLY
        if (format != AssemblyFormat.TiPackage)
            Console.WriteLine("NOTICE: Specified format was overridden to Package.\n");

        output = string.Join("", output.Split('.')[..^0]) + ".tpk";
        format = AssemblyFormat.TiPackage;
#endif

        Data = new(output, format, Sources, manifest);
    }

    public SourceFile[] Sources;
    public UnfinalizedAssembly Data;

    public bool DisableFinalization = false;

}
