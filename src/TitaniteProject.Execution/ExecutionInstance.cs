using System;

using TitaniteProject.Execution.Exceptions;

namespace TitaniteProject.Execution
{
    public delegate void StandardOutput(string conout);

    public class ExecutionInstance
    {
        internal StandardOutput Stdout;

        internal ProgramContext Program;

        internal FunctionMap<string> Instructions;
        internal ParameterlessFunctionMap Functions;

        internal VariableContext GlobalContext;
        internal VariableContext LocalContext;

        internal ulong Counter;

        public ExecutionInstance DefineStandardOutput(StandardOutput stdout)
        {
            this.Stdout = stdout;
            return this;
        }

        public ExecutionInstance LoadProgram(ProgramContext program)
        {
            this.Program = program;
            return this;
        }

        private FunctionMap<string> GenerateInstructionMap(in FunctionMap<string> map)
        {
            map.Clear();
            map.Register("dcl", (string operand) => Instruction.Declare.Execute(operand, this));
            map.Register("ass", (string operand) => Instruction.Assign.Execute(operand, this));
            map.Register("sto", (string operand) => Instruction.Store.Execute(operand, this));
            map.Register("lod", (string operand) => Instruction.Load.Execute(operand, this));
            map.Register("cpy", (string operand) => Instruction.Copy.Execute(operand, this));
            map.Register("cll", (string operand) => Instruction.Call.Execute(operand, this));
            map.Register("fnc", (string operand) => Instruction.Function.Execute(operand, this));
            map.Register("rtn", (string operand) => Instruction.Return.Execute(operand, this));
            return map;
        }
        
        private ParameterlessFunctionMap InstallDefaultFunctions(in ParameterlessFunctionMap map)
        {
            map.Clear();
            map.Register("puts", () => RuntimeFunction.PutString.Invoke(this));
            return map;
        }

        public void Run()
        {
            Instructions = new FunctionMap<string>();
            Functions = new ParameterlessFunctionMap();
            GlobalContext = new VariableContext();
            LocalContext = new VariableContext();

            Instructions = GenerateInstructionMap(Instructions);
            Functions = InstallDefaultFunctions(Functions);

            string[] lines = Program.Content.Split('\n');
            Counter = 0;

            LineProcessor processor = new LineProcessor(this);

            ExecutionStatus status = ExecutionStatus.Normal;

            while (status == ExecutionStatus.Normal)
            {
                status = processor.Process(lines[Counter]);
                ++Counter;
            }

            if (status == ExecutionStatus.EndOfProgram)
                return;

            if (status == ExecutionStatus.Corrupted)
                throw new ExecutionCorruptionException();

            if (status == ExecutionStatus.Normal)
                throw new ExecutionCorruptionException($"{ExecutionCorruptionException.CODE}: The execution loop was exited unexpectedly.");

            if (status == ExecutionStatus.InvalidInstruction || status == ExecutionStatus.InvalidOperands)
                throw new SyntaxErrorException(Counter);
        }
    }
}
