using System;

namespace TitaniteProject.Toolchain.Exceptions
{
    internal class ToolchainFinalizationException : Exception
    {
        public ToolchainFinalizationException(string message) : base(message) { }

        public ToolchainFinalizationException() : base("An error occurred during finalization.") { }
    }
}
