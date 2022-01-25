using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Collections;

namespace TitaniteProject.Execution.Contexts
{
    internal struct InstructionData
    {
        public byte Opcode;
        public OperandPair Operands;
    }
}
