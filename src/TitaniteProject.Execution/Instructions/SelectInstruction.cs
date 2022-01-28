using System;
using System.Collections.Generic;
using System.Text;
using TitaniteProject.Execution.Collections;
using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution.Instructions
{
    internal class SelectInstruction : Instruction
    {
        public override ExecutionStatus Execute(OperandPair operands, in ExecutionInstance ctx)
        {
            string identifier = ctx.Strings[operands.Left];
            ulong reference = ctx.LocalContext[identifier];
            int index = (int)operands.Right;

            ctx.Arrays[reference].SelectedElement = index;

            return ExecutionStatus.Normal;
        }
    }
}
