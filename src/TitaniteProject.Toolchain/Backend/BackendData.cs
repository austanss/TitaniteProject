
namespace TitaniteProject.Toolchain.Backend;

internal static class BackendData
{
    public const ulong PACKAGE_HEADER_MAGIC = 0x717A917E;
    public const ulong PACKAGE_HEADER_SIZE = sizeof(ulong) * 5;
    public const byte PACKAGE_STRING_OPCODE = 0xFF;
}
