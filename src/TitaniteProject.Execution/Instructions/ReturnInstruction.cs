using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;
using TitaniteProject.Execution.Collections;

namespace TitaniteProject.Execution.Instructions
{
    internal class ReturnInstruction : Instruction
    {
        public override ExecutionStatus Execute(OperandPair operands, in ExecutionInstance ctx)
        {
            if (ctx.CallStack.Depth == 0)
                return ExecutionStatus.EndOfProgram;

            ctx.InstructionPointer = ctx.CallStack.Current.ReturnPosition;

            ctx.CallStack.Shed();

            ctx.LocalContext = ctx.CallStack.Current.LocalVariables;

            return ExecutionStatus.Normal;
        }
    }
}
