using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitaniteProject.Toolchain
{
    internal enum AssemblyFormat : byte
    {
        Object = 000,
        Dll = 001,
        Elf = 002,
        Pe = 003
    }
}
