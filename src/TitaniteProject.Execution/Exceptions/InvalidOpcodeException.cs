using System;

namespace TitaniteProject.Execution.Exceptions
{
    internal class InvalidOpcodeException : Exception
    {
        public const string CODE = "TE-001";

        public InvalidOpcodeException(string message) : base(message) { }

        public InvalidOpcodeException() : base("The executable code contained an invalid opcode.") { }
    }
}
