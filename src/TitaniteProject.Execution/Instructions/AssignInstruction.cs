using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Instructions
{
    internal class AssignInstruction : Instruction
    {
        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            string identifier = operand.Split('=')[0];
            string value = operand.Remove(0, identifier.Length + 1).Replace('"', ' ').Trim();

            ctx.LocalContext[identifier] = value;

            return ExecutionStatus.Normal;
        }
    }
}
