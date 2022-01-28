using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;
using TitaniteProject.Execution.Collections;

using TitaniteProject.Commons;

namespace TitaniteProject.Execution.Instructions
{
    internal class JumpInstruction : Instruction
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
