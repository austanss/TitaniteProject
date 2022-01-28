using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;
using TitaniteProject.Execution.Collections;

using TitaniteProject.Commons;

namespace TitaniteProject.Execution.Instructions
{
    internal class Instruction
    {
        protected Instruction() { }

        public virtual ExecutionStatus Execute(OperandPair operands, in ExecutionInstance ctx) { return ExecutionStatus.Corrupted; }

        public static Instruction None = new EmptyInstruction();

        public static Instruction Define = new DefineInstruction();
        public static Instruction Move = new MoveInstruction();

        public static Instruction Write = new WriteInstruction();
        public static Instruction Read = new ReadInstruction();

        public static Instruction Jump = new JumpInstruction();
        public static Instruction Return = new ReturnInstruction();

        public static Instruction Split = new SplitInstruction();
        public static Instruction Select = new EmptyInstruction();

        public static Instruction Add = new AdditionInstruction();
        public static Instruction Subtract = new SubtractionInstruction();
        public static Instruction Multiply = new MultiplicationInstruction();
        public static Instruction Divide = new DivisionInstruction();
    }
}
