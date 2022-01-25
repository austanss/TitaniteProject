using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;
using TitaniteProject.Execution.Collections;

namespace TitaniteProject.Execution.Instructions
{
    internal class LoadInstruction : Instruction
    {
        public override ExecutionStatus Execute(OperandPair operands, in ExecutionInstance ctx)
        {
            string identifier = ctx.Strings[operands.Left];
            string alias = ctx.Strings[operands.Right];

            ctx.LocalContext[identifier] = ctx.ThreadContext[alias];

            return ExecutionStatus.Normal;
        }
    }
}
