using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution.Instructions
{
    internal class LoadInstruction : Instruction
    {
        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            string alias = operand.Split(',')[1].Trim();
            string identifier = operand.Split(',')[0].Trim();

            ctx.LocalContext[identifier] = ctx.ThreadContext[alias];

            return ExecutionStatus.Normal;
        }
    }
}
