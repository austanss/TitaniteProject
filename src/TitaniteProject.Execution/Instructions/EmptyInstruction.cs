using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;
using TitaniteProject.Execution.Collections;

using TitaniteProject.Commons;

namespace TitaniteProject.Execution.Instructions
{
    internal class EmptyInstruction : Instruction
    {
        public override ExecutionStatus Execute(OperandPair operands, in ExecutionInstance ctx)
        {
            return ExecutionStatus.Normal;
        }
    }
}
