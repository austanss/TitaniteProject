using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution.Instructions
{
    internal class MultiplicationInstruction : Instruction
    {
        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            string identifier = operand.Split(',')[0].Trim();
            ulong factor = Convert.ToUInt64(operand.Split(',')[1].Trim());

            ulong source = ctx.LocalContext[identifier];

            ulong product = source * factor;

            ctx.LocalContext[identifier] = product;

            return ExecutionStatus.Normal;
        }
    }
}
