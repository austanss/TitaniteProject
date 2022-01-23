
namespace TitaniteProject.Toolchain.Backend;

internal enum InstructionOpcode : byte
{
    Declare = 0x01,
    Assign = 0x02,
    String = 0x03,
    Store = 0x04,
    Load = 0x05,
    Copy = 0x06,
    Call = 0x07,
    Return = 0x08,
    Stall = 0x09,
    Add = 0x0A,
    Subtract = 0x0B,
    Multiply = 0x0C,
    Divide = 0x0D,
}
