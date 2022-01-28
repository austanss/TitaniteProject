using System;
using System.Collections.Generic;
using System.Text;
using TitaniteProject.Execution.Collections;
using TitaniteProject.Execution.Contexts;

using TitaniteProject.Commons;

namespace TitaniteProject.Execution.Instructions
{
    internal class SplitInstruction : Instruction
    {
        public override ExecutionStatus Execute(OperandPair operands, in ExecutionInstance ctx)
        {
            string identifier = ctx.Strings[operands.Left];
            int size = (int)operands.Right;

            ulong reference = ctx.Arrays.Create(identifier, size);

            ctx.LocalContext[identifier] = reference;

            return ExecutionStatus.Normal;
        }
    }
}
