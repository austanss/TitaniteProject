using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitaniteProject.Toolchain.Exceptions
{
    internal class BytecodeGenerationException : ToolchainException
    {
        public BytecodeGenerationException(string message) : base(message) { }

        public BytecodeGenerationException() : base("An error occurred during bytecode generation.") { }

        public override void Throw(string message) { throw new BytecodeGenerationException(message); }
    }
}
