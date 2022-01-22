using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitaniteProject.Toolchain
{
    internal class OutputAssembly
    {
        public OutputAssembly(string name, AssemblyFormat format, SourceFile[] sources)
        {
            Name = name;
            Format = format;
            Sources = sources;
        }

        public readonly string Name;
        public readonly AssemblyFormat Format;
        public readonly SourceFile[] Sources;
    }
}
