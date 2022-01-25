using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;
using TitaniteProject.Execution.Collections;

namespace TitaniteProject.Execution.Instructions
{
    internal class SubstractionInstruction : Instruction
    {
        public override ExecutionStatus Execute(OperandPair operands, in ExecutionInstance ctx)
        {
            string identifier = ctx.Strings[operands.Left];
            ulong subtrahend = operands.Right;

            ulong source = ctx.LocalContext[identifier];

            ulong difference = source - subtrahend;

            ctx.LocalContext[identifier] = difference;

            return ExecutionStatus.Normal;
        }
    }
}
