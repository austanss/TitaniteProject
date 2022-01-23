
namespace TitaniteProject.Toolchain.Frontends.Assembly;

internal record struct TranslatedInstruction
{
    public TranslatedInstruction(byte opcode, ulong[] operands)
    {
        Opcode = opcode;
        Operands = operands;
    }

    public byte Opcode { get; init; }
    public ulong[] Operands { get; init; }
}
