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

        public static Instruction Stall = new Instructions.StallInstruction();

        public static Instruction Declare = new Instructions.DeclareInstruction();
        public static Instruction Store = new Instructions.StoreInstruction();
        public static Instruction Load = new Instructions.LoadInstruction();

        public static Instruction Assign = new Instructions.AssignInstruction();
        public static Instruction Copy = new Instructions.CopyInstruction();

        public static Instruction Call = new Instructions.CallInstruction();
        public static Instruction Return = new Instructions.ReturnInstruction();

        public static Instruction Add = new Instructions.AdditionInstruction();
        public static Instruction Substract = new Instructions.SubstractionInstruction();
        public static Instruction Multiply = new Instructions.MultiplicationInstruction();
        public static Instruction Divide = new Instructions.DivisionInstruction();
    }
}
