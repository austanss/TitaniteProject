
namespace TitaniteProject.Toolchain.Frontends.Assembly;

internal record struct TranslatedInstruction
{
    public TranslatedInstruction(byte opcode, byte modifier, OperandPair operands)
    {
        Opcode = opcode;
        Modifier = modifier;
        Operands = operands;
    }

    public byte Opcode { get; init; }
    public byte Modifier { get; init; }
    public OperandPair Operands { get; init; }
}
