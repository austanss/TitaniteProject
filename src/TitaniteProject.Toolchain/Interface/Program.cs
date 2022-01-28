global using System;
global using System.IO;
global using System.Linq;

global using TitaniteProject.Commons;

global using TitaniteProject.Toolchain.Interface;
global using TitaniteProject.Toolchain.Exceptions;
global using TitaniteProject.Toolchain.Frontends;
global using TitaniteProject.Toolchain.Frontends.Assembly;
global using TitaniteProject.Toolchain.Backend;

namespace TitaniteProject.Toolchain.Interface;

public static class Program
{
    const string VERSION_STRING = "TACC [P4]";

    public static void Main(string[] args)
    {
        Console.WriteLine($"\t -- {VERSION_STRING} -- \n\n");

        if (args.Length == 0)
        {
            ToolchainError.TC0001.Throw(null);
            Environment.Exit(-1);
        }

        CompilationContext context = new(args);

        Compiler compiler = new(context);

        compiler.Compile();

        return;
    }
}
