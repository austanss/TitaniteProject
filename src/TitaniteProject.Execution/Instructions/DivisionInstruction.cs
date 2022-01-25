using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;
using TitaniteProject.Execution.Collections;

namespace TitaniteProject.Execution.Instructions
{
    internal class DivisionInstruction : Instruction
    {
        public override ExecutionStatus Execute(OperandPair operands, in ExecutionInstance ctx)
        {
            string identifier = ctx.Strings[operands.Left];
            ulong divisor = operands.Right;

            ulong source = ctx.LocalContext[identifier];

            ulong quotient = source * divisor;

            ctx.LocalContext[identifier] = quotient;

            return ExecutionStatus.Normal;
        }
    }
}
