using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Instructions
{
    internal class LoadInstruction : Instruction
    {
        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            string alias = operand.Split(':')[0];
            string identifier = operand.Split(':')[1];

            ctx.LocalContext[identifier] = ctx.GlobalContext[alias];

            return ExecutionStatus.Normal;
        }
    }
}
