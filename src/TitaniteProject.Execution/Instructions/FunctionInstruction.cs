using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Instructions
{
    internal class FunctionInstruction : Instruction
    {
        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            ExecutionInstance instance = ctx;

            string identifier = operand.Replace(':', ' ').Trim();

            ulong line = ctx.Counter;

            new Functions.UserDefinedFunction(line);

            ctx.Functions.Register(identifier, () => Functions.UserDefinedFunction.List[line].Invoke(instance));

            return ExecutionStatus.Normal;
        }
    }
}
