using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Exceptions
{
    internal class SyntaxErrorException : Exception
    {
        public const string CODE = "TE-003";

        public SyntaxErrorException(string message) : base(message) { }

        public SyntaxErrorException() : base($"{CODE}: The loaded program contained one or more syntax errors.") { }

        public SyntaxErrorException(ulong line) : base($"{CODE}: The loaded program contains a syntax error at line {line}.") { }
    }
}
