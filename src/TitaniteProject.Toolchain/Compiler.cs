
namespace TitaniteProject.Toolchain;

internal class Compiler
{
    public Compiler(CompilationContext context)
    {
        assembly = context.Output;
        manifest = context.Manifest;
    }

    readonly UnfinalizedAssembly assembly;
    readonly ProgramManifest manifest;

    public void Compile()
    {
        if (assembly is null || manifest is null)
        {
            ToolchainError.TC0000.Throw(null);
            throw new Exception();
        }

        Array.Resize(ref assembly.Objects, assembly.Sources.Length);

        foreach ((SourceFile source, int i) in assembly.Sources.WithIndex())
        {
            assembly.Objects[i] = source.Language switch
            {
                SourceLanguage.Assembly => new AssembledObject($"OBJ{i}", source).Object,
                _ => new ObjectFile("null")
            };

            if (assembly.Objects[i].Identifier == "null")
            {
                ToolchainError.TC0002.Throw(source.FileName);
                throw new Exception();
            }
        }

        Console.WriteLine("\n\nNo assembly was generated.\n\n");
    }
}
