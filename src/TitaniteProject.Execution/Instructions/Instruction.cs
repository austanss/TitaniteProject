using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution.Instructions
{
    internal class Instruction
    {
        protected Instruction() { }

        public virtual ExecutionStatus Execute(string operand, in ExecutionInstance ctx) { return ExecutionStatus.Corrupted; }

        public static Instruction Null = new Instructions.NullInstruction();

        public static Instruction Declare = new Instructions.DeclareInstruction();
        public static Instruction Store = new Instructions.StoreInstruction();
        public static Instruction Load = new Instructions.LoadInstruction();

        public static Instruction AssignString = new Instructions.AssignStringInstruction();
        public static Instruction AssignInteger = new Instructions.AssignIntegerInstruction();
        public static Instruction Copy = new Instructions.CopyInstruction();

        public static Instruction Call = new Instructions.CallInstruction();
        public static Instruction Return = new Instructions.ReturnInstruction();

        public static Instruction Add = new Instructions.AdditionInstruction();
        public static Instruction Substract = new Instructions.SubstractionInstruction();
        public static Instruction Multiply = new Instructions.MultiplicationInstruction();
        public static Instruction Divide = new Instructions.DivisionInstruction();
    }
}
