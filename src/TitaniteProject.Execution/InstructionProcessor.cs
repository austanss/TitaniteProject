using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;
using TitaniteProject.Execution.Collections;

namespace TitaniteProject.Execution
{
    internal class InstructionProcessor
    {
        public InstructionProcessor(in ExecutionInstance ctx)
            => instance = ctx;

        private readonly ExecutionInstance instance;

        public ExecutionStatus Process(InstructionData instruction)
        {
            return instruction.Opcode > 0x0C
                ? ExecutionStatus.InvalidInstruction
                : instance.Instructions[instruction.Opcode](instruction.Operands);
        }
    }
}
