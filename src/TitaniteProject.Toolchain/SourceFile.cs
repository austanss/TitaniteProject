using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitaniteProject.Toolchain
{
    internal class SourceFile
    {
        public SourceFile(string filename, SourceLanguage language)
        {
            FileName = filename;
            Language = language;
        }

        public readonly string FileName;
        public readonly SourceLanguage Language;
    }
}
