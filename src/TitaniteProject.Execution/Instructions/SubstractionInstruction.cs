using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution.Instructions
{
    internal class SubstractionInstruction : Instruction
    {
        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            string identifier = operand.Split('-')[0].Trim();
            ulong subtrahend = Convert.ToUInt64(operand.Split('-')[1].Trim());

            ulong source = ctx.LocalContext[identifier];

            ulong difference = source - subtrahend;

            ctx.LocalContext[identifier] = difference;

            return ExecutionStatus.Normal;
        }
    }
}
