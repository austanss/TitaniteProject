using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitaniteProject.Toolchain.Exceptions
{
    internal class CompilationInitiationException : ToolchainException
    {
        public CompilationInitiationException(string message) : base(message) { }

        public CompilationInitiationException() : base("An error occurred during compiler initiation.") { }

        public override void Throw(string message) { throw new CompilationInitiationException(message); }
    }
}
