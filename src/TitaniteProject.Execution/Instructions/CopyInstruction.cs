using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Instructions
{
    internal class CopyInstruction : Instruction
    {
        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            string source = operand.Split('/')[0];
            string destination = operand.Split('/')[1];

            ctx.LocalContext[destination] = ctx.LocalContext[source];

            return ExecutionStatus.Normal;
        }
    }
}
