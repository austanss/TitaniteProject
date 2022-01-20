using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Exceptions;
using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution.Instructions
{
    internal class DeclareInstruction : Instruction
    {
        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            string identifier = UncanonicalIdentifierException.Check(operand.Trim());

            ctx.LocalContext.Declare(identifier);

            return ExecutionStatus.Normal;
        }
    }
}
