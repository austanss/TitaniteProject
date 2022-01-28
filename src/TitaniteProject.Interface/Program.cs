using System;

using TitaniteProject.Execution;
using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Interface
{
    public static class Program
    {
        const string VERSION_STRING = "TExI [P4]";

        internal static void Output(string data)
            => Console.WriteLine(data);

        public static void Main(string[] args)
        {
            Console.WriteLine($"\t -- {VERSION_STRING} -- \n");

            if (args.Length != 1)
            {
                Console.WriteLine("NOTICE: Arguments are to be implemented in phase Alpha.\n\n");
                Console.WriteLine("Usage: texi <executable>\n");
                Console.WriteLine("Details: The file path should point to a Ti executable in a supported format.");
                return;
            }

            ProgramPackage program = new ProgramLoader().LoadFile(args[0]).RetrieveProgram();

            Console.WriteLine($"\nLoading program \"{program.Name}\" (version {program.Version})...\n\n\n");

            ExecutionInstance instance = new(program, (string text) => Output(text));

            instance.Run();

            Console.WriteLine("\n\n\n");
        }
    }
}
