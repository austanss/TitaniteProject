
namespace TitaniteProject.Commons
{
    internal struct InstructionData
    {
        public InstructionData(byte opcode, byte modifier, OperandPair operands)
        {
            Opcode = opcode;
            Modifier = modifier;
            Operands = operands;
        }

        public byte Opcode;
        public byte Modifier;
        public OperandPair Operands;
    }
}
