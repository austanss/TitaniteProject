using System;

using TitaniteProject.Toolchain.Exceptions;

namespace TitaniteProject.Toolchain.Interface
{
    public static class Program
    {
        const string VERSION_STRING = "TACC [P3]";

        public static void Main(string[] args)
        {
            Console.WriteLine($"\t -- {VERSION_STRING} -- \n");

            if (args.Length == 0)
                throw new InsufficientArgumentsException();

            CompilationContext context = new(args);

            Compiler compiler = new(context);

            compiler.Compile();

            return;
        }
    }
}
