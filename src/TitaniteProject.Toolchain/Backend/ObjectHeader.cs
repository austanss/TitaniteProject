﻿
namespace TitaniteProject.Toolchain.Backend;

internal record struct ObjectHeader
{
    public ulong Magic => BackendData.PACKAGE_HEADER_MAGIC;
    public ulong CodeOffset => BackendData.PACKAGE_HEADER_SIZE;
    public ulong SymbolTableOffset { get; init; }
    public ulong StringTableOffset { get; init; }
}
