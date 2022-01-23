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
        public abstract Symbol[] Symbols { get; protected set; }
        public abstract TabledString[] Strings { get; protected set; }
    }
}
