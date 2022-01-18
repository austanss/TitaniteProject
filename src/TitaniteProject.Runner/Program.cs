using System;

using TitaniteProject.Execution;
using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Runner
{
    public class Program
    {
        const string VERSION_STRING = "ProtoTPR Two";

        public static void Main(string[] args)
        {
            Console.WriteLine($"\t -- {VERSION_STRING} -- \n");
            
            if (args.Length > 0)
                throw new NotImplementedException("Switches and arguments are not supported.");

            ProgramContext program = new ProgramLoader().LoadConfiguration("runner.cfg").RetrieveProgram();

            Console.WriteLine($"\nLoading program \"{program.Name}\" (version {program.Version})...\n\n\n");

            ExecutionInstance environment = new ExecutionInstance();
            environment.DefineStandardOutput((conout) => Console.WriteLine(conout)).LoadProgram(program);

            environment.Run();

            Console.WriteLine("\n\n\n");
        }
    }
}
