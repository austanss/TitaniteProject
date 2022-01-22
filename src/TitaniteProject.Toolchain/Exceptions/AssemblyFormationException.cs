using System;

namespace TitaniteProject.Toolchain.Exceptions
{
    internal class AssemblyFormationException : Exception
    {
        public AssemblyFormationException(string message) : base(message) { }

        public AssemblyFormationException() : base("An error occurred during assembly formation.") { }
    }
}
