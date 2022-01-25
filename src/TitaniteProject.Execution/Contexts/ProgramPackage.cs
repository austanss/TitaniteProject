using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace TitaniteProject.Execution.Contexts
{
    public struct ProgramPackage
    {
        public string Name;
        public string Description;
        public string Author;
        public string Version;
        public MemoryStream Code;
        public MemoryStream SymbolTable;
        public MemoryStream StringTable;

        public void CreateStreams()
        {
            if (Code != null)
                return;

            Code = new MemoryStream();
            SymbolTable = new MemoryStream();
            StringTable = new MemoryStream();
        }
    }
}
