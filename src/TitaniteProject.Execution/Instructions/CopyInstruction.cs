using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;
using TitaniteProject.Execution.Collections;

namespace TitaniteProject.Execution.Instructions
{
    internal class CopyInstruction : Instruction
    {
        public override ExecutionStatus Execute(OperandPair operands, in ExecutionInstance ctx)
        {
            string source = ctx.Strings[operands.Right];
            string destination = ctx.Strings[operands.Left];

            ctx.LocalContext[destination] = ctx.LocalContext[source];

            return ExecutionStatus.Normal;
        }
    }
}
