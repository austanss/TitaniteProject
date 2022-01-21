using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution.Instructions
{
    internal class StoreInstruction : Instruction
    {
        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            string identifier = operand.Split(',')[1].Trim();
            string alias = operand.Split(',')[0].Trim();

            if (!ctx.ThreadContext.Contains(alias))
                ctx.ThreadContext.Declare(alias);

            ctx.ThreadContext[alias] = ctx.LocalContext[identifier];

            return ExecutionStatus.Normal;
        }
    }
}
