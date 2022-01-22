using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TitaniteProject.Toolchain.Interface;
using TitaniteProject.Toolchain.Exceptions;

namespace TitaniteProject.Toolchain
{
    internal class Compiler
    {
        public Compiler(CompilationContext context)
        {
            assembly = context.Output;
            manifest = context.Manifest;
        }

        readonly OutputAssembly assembly;
        readonly ProgramManifest manifest;

        public void Compile()
        {
            if (assembly == null || manifest == null)
                ToolchainError.TC0001.Throw();

            Console.WriteLine("\n\nNo assembly was generated.\n\n");
        }
    }
}
