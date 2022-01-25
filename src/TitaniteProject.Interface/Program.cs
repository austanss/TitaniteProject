using System;

using TitaniteProject.Execution;
using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Interface
{
    public static class Program
    {
        const string VERSION_STRING = "TExI [P3]";

        internal static void Output(string data)
            => Console.WriteLine(data);

        public static void Main(string[] args)
        {
            Console.WriteLine($"\t -- {VERSION_STRING} -- \n");

            if (args.Length > 0)
            {
                Console.WriteLine("NOTICE: Arguments are to be implemented in phase Alpha.\n");
                Console.WriteLine("Usage: texi .\n");
                Console.WriteLine("Details: The current working directory should contain a valid 'texi.config' file.");
                return;
            }

            ProgramPackage program = new ProgramLoader().LoadConfiguration("texi.config").RetrieveProgram();

            Console.WriteLine($"\nLoading program \"{program.Name}\" (version {program.Version})...\n\n\n");

            ExecutionInstance instance = new(program, (string text) => Output(text));

            instance.Run();

            Console.WriteLine("\n\n\n");
        }
    }
}
