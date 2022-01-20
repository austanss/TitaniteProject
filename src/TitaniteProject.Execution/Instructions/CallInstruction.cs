using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution.Instructions
{
    internal class CallInstruction : Instruction
    {
        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            string identifier = operand.Trim();

            ctx.CallStack.Add(new CallStackFrame(ctx.Counter));

            ctx.LocalContext = ctx.CallStack.Current.LocalVariables;

            return ctx.Functions[identifier]();
        }
    }
}
