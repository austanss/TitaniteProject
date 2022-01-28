
namespace TitaniteProject.Toolchain.Frontends.Assembly;

internal static class AssemblerData
{
    public static readonly Dictionary<string, byte> TranslationTable = new()
    {
        { "def", (byte)InstructionOpcode.Define },
        { "mvv", (byte)InstructionOpcode.Move },
        { "wrr", (byte)InstructionOpcode.Write },
        { "rdd", (byte)InstructionOpcode.Read },
        { "jmp", (byte)InstructionOpcode.Jump },
        { "ret", (byte)InstructionOpcode.Return },
        { "nop", (byte)InstructionOpcode.None },
        { "spl", (byte)InstructionOpcode.Split },
        { "slc", (byte)InstructionOpcode.Select },
        { "add", (byte)InstructionOpcode.Add },
        { "sub", (byte)InstructionOpcode.Subtract },
        { "mul", (byte)InstructionOpcode.Multiply },
        { "div", (byte)InstructionOpcode.Divide },
    };

    public const char LABEL_INDICATOR = ':';
    public const string NULL_PARAMETER = "\0\0\0\0";

    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
        => self.Select((item, index) => (item, index));
}
