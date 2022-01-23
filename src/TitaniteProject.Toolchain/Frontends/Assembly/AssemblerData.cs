
namespace TitaniteProject.Toolchain.Frontends.Assembly;

internal static class AssemblerData
{
    public static readonly Dictionary<string, byte> TranslationTable = new()
    {
        { "dcl", (byte)InstructionOpcode.Declare },
        { "aiv", (byte)InstructionOpcode.Assign },
        { "asv", (byte)InstructionOpcode.Assign },
        { "sto", (byte)InstructionOpcode.Store },
        { "lod", (byte)InstructionOpcode.Load },
        { "cpy", (byte)InstructionOpcode.Copy },
        { "cll", (byte)InstructionOpcode.Call },
        { "rtn", (byte)InstructionOpcode.Return },
        { "nop", (byte)InstructionOpcode.Stall },
        { "add", (byte)InstructionOpcode.Add },
        { "sub", (byte)InstructionOpcode.Subtract },
        { "mul", (byte)InstructionOpcode.Multiply },
        { "div", (byte)InstructionOpcode.Divide },
    };

    public const string FUNCTION_MNEMONIC = "fnc";
    public const string NULL_PARAMETER = "\0\0\0\0";

    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
        => self.Select((item, index) => (item, index));
}
