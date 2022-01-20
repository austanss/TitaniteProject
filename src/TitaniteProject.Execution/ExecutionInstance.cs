using System;
using System.Collections.Generic;

using TitaniteProject.Execution.Exceptions;
using TitaniteProject.Execution.Contexts;
using TitaniteProject.Execution.Collections;
using TitaniteProject.Execution.Preliminary;
using TitaniteProject.Execution.IO;

namespace TitaniteProject.Execution
{
    public delegate void StandardOutput(string conout);

    public class ExecutionInstance
    {
        internal StandardOutput Stdout;

        internal ProgramContext Program;

        internal FunctionMap<string> Instructions;
        internal ParameterlessFunctionMap Functions;

        internal VariableContext ThreadContext;
        internal VariableContext LocalContext;

        internal CallStack CallStack;

        internal AllocatedCollection<string> Strings;

        internal IOManager IO;

        internal ulong Counter;

        public bool Instantiated;

        public ExecutionInstance(ProgramContext program, StandardOutput stdout)
        {
            Program = program;
            Stdout = stdout;

            Instructions = new FunctionMap<string>();
            Functions = new ParameterlessFunctionMap();

            Instructions = GenerateInstructionMap(Instructions);

            CallStack = new CallStack();

            LocalContext = CallStack.Current.LocalVariables;
            ThreadContext = new VariableContext();
            Strings = new AllocatedCollection<string>();

            IO = new IOManager(this);

            ulong[] functions = new FunctionSweep(program).Catalyze();
            string[] declarations = new ArraySelection<string>(program.Content.Split('\n'), functions).Catalyze();

            if (declarations.Length != functions.Length)
                throw new ExecutionCorruptionException();

            for (int i = 0; i < declarations.Length; i++)
            {
                string identifier = declarations[i].Replace('\r', ' ').Trim();
                identifier = identifier[4..(identifier.Length - 1)];

                new UserDefinedFunction(identifier, functions[i]);
                Functions.Register(identifier, () => UserDefinedFunction.List[identifier].Invoke(this));
            }

            Counter = 0;
        }

        private FunctionMap<string> GenerateInstructionMap(in FunctionMap<string> map)
        {
            map.Clear();
            map.Register("dcl", (string operand) => Instruction.Declare.Execute(operand, this));
            map.Register("asv", (string operand) => Instruction.AssignString.Execute(operand, this));
            map.Register("aiv", (string operand) => Instruction.AssignInteger.Execute(operand, this));
            map.Register("sto", (string operand) => Instruction.Store.Execute(operand, this));
            map.Register("lod", (string operand) => Instruction.Load.Execute(operand, this));
            map.Register("cpy", (string operand) => Instruction.Copy.Execute(operand, this));
            map.Register("cll", (string operand) => Instruction.Call.Execute(operand, this));
            map.Register("rtn", (string operand) => Instruction.Return.Execute(operand, this));
            map.Register("fnc", (string operand) => Instruction.Null.Execute(operand, this));
            return map;
        }

        public void Run()
        {
            string[] lines = Program.Content.Split('\n');

            InstructionParser processor = new InstructionParser(this);

            ExecutionStatus status = ExecutionStatus.Normal;

            while (status == ExecutionStatus.Normal)
            {
                IO.Check();

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
