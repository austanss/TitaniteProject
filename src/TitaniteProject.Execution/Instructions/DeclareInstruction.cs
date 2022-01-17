using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Exceptions;

namespace TitaniteProject.Execution.Instructions
{
    internal class DeclareInstruction : Instruction
    {
        private string Sanitize(string identifier)
        {
            char[] mutableIdentifier = identifier.ToCharArray();

            for (int i = 0; i < mutableIdentifier.Length; i++)
            {
                if (mutableIdentifier[i] > '9' || mutableIdentifier[i] < '0')
                    if (mutableIdentifier[i] > 'z' || mutableIdentifier[i] < 'a')
                        if (mutableIdentifier[i] > 'Z' || mutableIdentifier[i] < 'A')
                            throw new UncanonicalIdentifierException($"{UncanonicalIdentifierException.CODE}: The identifier ({identifier}) contained incorrect syntax.");
            }

            return identifier;
        }

        public override ExecutionStatus Execute(string operand, in ExecutionInstance ctx)
        {
            string identifier = Sanitize(operand.Split('.')[1]);

            ctx.LocalContext[identifier] = "null";

            return ExecutionStatus.Normal;
        }
    }
}
