using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Instructions
{
    internal class CallInstruction : Instruction
    {
        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            string identifier = operand.Trim();

            return ctx.Functions[identifier]();
        }
    }
}
