
namespace TitaniteProject.Toolchain.Backend;

internal enum InstructionOpcode : byte
{
    Declare = 0x01,
    Assign = 0x02,
    Store = 0x03,
    Load = 0x04,
    Copy = 0x05,
    Call = 0x06,
    Return = 0x07,
    Stall = 0x08,
    Add = 0x09,
    Subtract = 0x0A,
    Multiply = 0x0B,
    Divide = 0x0C,
    String = 0x0D,
}
