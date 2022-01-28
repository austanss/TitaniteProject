
namespace TitaniteProject.Toolchain.Backend;

internal enum InstructionOpcode : byte
{
    Define = 0x01,
    Move = 0x02,
    Write = 0x03,
    Read = 0x04,
    Jump = 0x05,
    Return = 0x06,
    None = 0x07,
    Split = 0x08,
    Select = 0x09,
    Add = 0x0A,
    Subtract = 0x0B,
    Multiply = 0x0C,
    Divide = 0x0D,
}
