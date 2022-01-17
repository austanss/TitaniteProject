using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Instructions
{
    internal class ReturnInstruction : Instruction
    {
        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            return ExecutionStatus.EndOfProgram;
        }
    }
}
