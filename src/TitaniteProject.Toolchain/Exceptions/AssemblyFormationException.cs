using System;

namespace TitaniteProject.Toolchain.Exceptions
{
    internal class AssemblyFormationException : ToolchainException
    {
        public AssemblyFormationException(string message) : base(message) { }

        public AssemblyFormationException() : base("An error occurred during assembly formation.") { }

        public override void Throw(string message) { throw new AssemblyFormationException(message); }
    }
}
