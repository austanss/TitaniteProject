
namespace TitaniteProject.Toolchain;

internal class Compiler
{
    public Compiler(CompilationContext context)
        => ctx = context;

    readonly CompilationContext ctx;

    public void Compile()
    {
        if (ctx.Data is null || ctx.Data.Manifest is null)
        {
            ToolchainError.TC0000.Throw(null);
            throw new Exception();
        }

        Array.Resize(ref ctx.Data.Objects, ctx.Data.Sources.Length);

        foreach ((SourceFile source, int i) in ctx.Data.Sources.WithIndex())
        {
            ctx.Data.Objects[i] = source.Language switch
            {
                SourceLanguage.Assembly => new ParsedAssemblySource(source),
                _ => null
            };

            if (ctx.Data.Objects[i] is null)
            {
                ToolchainError.TC0002.Throw(source.FileName);
                throw new Exception();
            }
        }

        if (ctx.DisableFinalization)
        {
            Console.WriteLine("\n\nAssembly finalization disabled: no assembly was generated.\n\n");
            return;
        }

        FinalizedTiPackageAssembly assembly = new(ctx.Data);

        FileStream output = File.OpenWrite(assembly.FileName);

        _ = assembly.Data.Seek(0, SeekOrigin.Begin);
        assembly.Data.CopyTo(output);

        output.Flush();

        output.Dispose();
        assembly.Data.Dispose();
    }
}
