using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitaniteProject.Toolchain.Frontends
{
    internal abstract record class ParsedSource
    {
        public abstract TranslatedInstruction[] Instructions { get; protected set; }
        public abstract TiPackageSymbol[] Symbols { get; protected set; }
        public abstract TiPackageString[] Strings { get; protected set; }
    }
}
