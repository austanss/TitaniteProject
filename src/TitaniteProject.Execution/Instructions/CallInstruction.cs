using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;
using TitaniteProject.Execution.Collections;

namespace TitaniteProject.Execution.Instructions
{
    internal class CallInstruction : Instruction
    {
        public override ExecutionStatus Execute(OperandPair operands, in ExecutionInstance ctx)
        {
            ulong position = ctx.Symbols[operands.Left];

            ctx.CallStack.Add(new CallStackFrame(ctx.InstructionPointer));

            ctx.LocalContext = ctx.CallStack.Current.LocalVariables;

            ctx.InstructionPointer = position;

            return ExecutionStatus.Normal;
        }
    }
}
