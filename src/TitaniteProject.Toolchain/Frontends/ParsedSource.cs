using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitaniteProject.Toolchain.Frontends
{
    internal abstract record class ParsedSource
    {
        public abstract InstructionData[] Instructions { get; protected set; }
        public abstract PackageSymbol[] Symbols { get; protected set; }
        public abstract PackageString[] Strings { get; protected set; }
    }
}
