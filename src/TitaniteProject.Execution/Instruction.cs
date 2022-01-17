﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution
{
    internal class Instruction
    {
        protected Instruction() { }

        public virtual ExecutionStatus Execute(string operand, in ExecutionInstance ctx) { return ExecutionStatus.Corrupted; }

        public static Instruction Declare = new Instructions.DeclareInstruction();
        public static Instruction Assign = new Instructions.AssignInstruction();
        public static Instruction Store = new Instructions.StoreInstruction();
        public static Instruction Load = new Instructions.LoadInstruction();
        public static Instruction Copy = new Instructions.CopyInstruction();
        public static Instruction Call = new Instructions.CallInstruction();
        public static Instruction Function = new Instructions.FunctionInstruction();
        public static Instruction Return = new Instructions.ReturnInstruction();
    }
}