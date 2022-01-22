using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitaniteProject.Toolchain
{
    internal enum SourceLanguage : byte
    {
        Undetected = 000,
        Assembly = 001,
        Ti = 002,
    }
}
