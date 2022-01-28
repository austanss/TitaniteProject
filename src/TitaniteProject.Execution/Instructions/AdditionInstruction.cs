using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;
using TitaniteProject.Execution.Collections;

using TitaniteProject.Commons;

namespace TitaniteProject.Execution.Instructions
{
    internal class AdditionInstruction : Instruction
    {
        public override ExecutionStatus Execute(OperandPair operands, in ExecutionInstance ctx)
        {
            string identifier = ctx.Strings[operands.Left];
            ulong addend = operands.Right;

            ulong source = ctx.LocalContext[identifier];

            ulong sum = source + addend;

            ctx.LocalContext[identifier] = sum;

            return ExecutionStatus.Normal;
        }
    }
}
