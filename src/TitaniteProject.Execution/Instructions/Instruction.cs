using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;
using TitaniteProject.Execution.Collections;

namespace TitaniteProject.Execution.Instructions
{
    internal class Instruction
    {
        protected Instruction() { }

        public virtual ExecutionStatus Execute(OperandPair operands, in ExecutionInstance ctx) { return ExecutionStatus.Corrupted; }

        public static Instruction None = new Instructions.EmptyInstruction();

        public static Instruction Define = new Instructions.DefineInstruction();
        public static Instruction Set = new Instructions.SetInstruction();

        public static Instruction Write = new Instructions.WriteInstruction();
        public static Instruction Read = new Instructions.ReadInstruction();

        public static Instruction Jump = new Instructions.JumpInstruction();
        public static Instruction Return = new Instructions.ReturnInstruction();

        public static Instruction Split = new Instructions.EmptyInstruction();
        public static Instruction Select = new Instructions.EmptyInstruction();

        public static Instruction Add = new Instructions.AdditionInstruction();
        public static Instruction Subtract = new Instructions.SubtractionInstruction();
        public static Instruction Multiply = new Instructions.MultiplicationInstruction();
        public static Instruction Divide = new Instructions.DivisionInstruction();
    }
}
