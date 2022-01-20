using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution.Instructions
{
    internal class AssignStringInstruction : Instruction
    {
        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            string identifier = operand.Split('=')[0];
            string value = operand.Remove(0, identifier.Length + 1).Replace('"', ' ').Trim();

            ulong reference = (ulong)ctx.Strings.Add(value);

            ctx.LocalContext[identifier] = reference;

            return ExecutionStatus.Normal;
        }
    }
}
