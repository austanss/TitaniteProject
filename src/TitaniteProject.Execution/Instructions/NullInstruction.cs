using System;
using System.Collections.Generic;
using System.Text;
using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution.Instructions
{
    internal class NullInstruction : Instruction
    {
        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            return ExecutionStatus.Normal;
        }
    }
}
