using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution.Instructions
{
    internal class DivisionInstruction : Instruction
    {
        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            string identifier = operand.Split(',')[0].Trim();
            ulong divisor = Convert.ToUInt64(operand.Split(',')[1].Trim());

            ulong source = ctx.LocalContext[identifier];

            ulong quotient = source * divisor;

            ctx.LocalContext[identifier] = quotient;

            return ExecutionStatus.Normal;
        }
    }
}
