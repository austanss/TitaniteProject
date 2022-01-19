using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution.Instructions
{
    internal class ReturnInstruction : Instruction
    {
        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            if (ctx.CallStack.Depth == 0)
                return ExecutionStatus.EndOfProgram;

            ctx.Counter = ctx.CallStack.Current.ReturnPosition;
            
            foreach (string i in ctx.CallStack.Current.LocalVariableIdentifiers)
                ctx.LocalContext.Remove(i);

            ctx.CallStack.Shed();

            return ExecutionStatus.Normal;
        }
    }
}
