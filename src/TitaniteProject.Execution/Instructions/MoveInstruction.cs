using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;
using TitaniteProject.Execution.Collections;

using TitaniteProject.Commons;

namespace TitaniteProject.Execution.Instructions
{
    internal class MoveInstruction : Instruction
    {
        public override ExecutionStatus Execute(OperandPair operands, in ExecutionInstance ctx)
        {
            string identifier = ctx.Strings[operands.Left];
            ulong value = operands.Right;

            ulong? reference = ctx.Arrays.Contains(identifier) ?
                ctx.LocalContext[identifier] : (ulong?)null;

            _ = reference.HasValue ?
                ctx.Arrays[reference.Value][ctx.Arrays[reference.Value].SelectedElement] :
                ctx.LocalContext[identifier] = value;

            return ExecutionStatus.Normal;
        }
    }
}
