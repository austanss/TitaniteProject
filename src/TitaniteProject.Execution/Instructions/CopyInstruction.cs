using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution.Instructions
{
    internal class CopyInstruction : Instruction
    {
        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            string source = operand.Split(',')[1].Trim();
            string destination = operand.Split(',')[0].Trim();

            ctx.LocalContext[destination] = ctx.LocalContext[source];

            return ExecutionStatus.Normal;
        }
    }
}
