using System;

using TitaniteProject.Execution;
using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Runner
{
    public static class Program
    {
        const string VERSION_STRING = "ProtoTPR Two";

        internal static void Output(string data)
            => Console.WriteLine(data);

        public static void Main(string[] args)
        {
            Console.WriteLine($"\t -- {VERSION_STRING} -- \n");
            
            if (args.Length > 0)
                throw new NotImplementedException("Switches and arguments are not supported.");

            ProgramContext program = new ProgramLoader().LoadConfiguration("runner.cfg").RetrieveProgram();

            Console.WriteLine($"\nLoading program \"{program.Name}\" (version {program.Version})...\n\n\n");

            ExecutionInstance instance = new(program, (string text) => Output(text));

            instance.Run();

            Console.WriteLine("\n\n\n");
        }
    }
}
