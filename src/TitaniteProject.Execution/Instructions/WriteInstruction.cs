using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;
using TitaniteProject.Execution.Collections;

using TitaniteProject.Commons;

namespace TitaniteProject.Execution.Instructions
{
    internal class WriteInstruction : Instruction
    {
        public override ExecutionStatus Execute(OperandPair operands, in ExecutionInstance ctx)
        {
            string identifier = ctx.Strings[operands.Right];
            string alias = ctx.Strings[operands.Left];

            if (!ctx.ThreadContext.Contains(alias))
                ctx.ThreadContext.Declare(alias);

            ctx.ThreadContext[alias] = ctx.LocalContext[identifier];

            return ExecutionStatus.Normal;
        }
    }
}
