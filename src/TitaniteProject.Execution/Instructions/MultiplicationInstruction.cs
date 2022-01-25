using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;
using TitaniteProject.Execution.Collections;

namespace TitaniteProject.Execution.Instructions
{
    internal class MultiplicationInstruction : Instruction
    {
        public override ExecutionStatus Execute(OperandPair operands, in ExecutionInstance ctx)
        {
            string identifier = ctx.Strings[operands.Left];
            ulong factor = operands.Right;

            ulong source = ctx.LocalContext[identifier];

            ulong product = source * factor;

            ctx.LocalContext[identifier] = product;

            return ExecutionStatus.Normal;
        }
    }
}
