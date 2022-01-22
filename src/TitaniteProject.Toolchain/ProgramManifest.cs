using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitaniteProject.Toolchain
{
    internal class ProgramManifest
    {
        public ProgramManifest(string? filename)
        {
            if (filename == null)
            {
                Content = "content: null";
                return;
            }

            Content = new StreamReader(filename).ReadToEnd();
        }

        public string Content;
    }
}
