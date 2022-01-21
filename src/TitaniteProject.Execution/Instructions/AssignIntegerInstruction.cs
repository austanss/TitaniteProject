using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution.Instructions
{
    internal class AssignIntegerInstruction : Instruction
    {
        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            string identifier = operand.Split(',')[0].Trim();
            ulong value = Convert.ToUInt64(operand.Split(',')[1].Trim());

            ctx.LocalContext[identifier] = value;

            return ExecutionStatus.Normal;
        }
    }
}
