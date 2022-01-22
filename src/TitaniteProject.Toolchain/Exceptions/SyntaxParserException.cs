using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitaniteProject.Toolchain.Exceptions
{
    internal class SyntaxParserException : Exception
    {
        public SyntaxParserException(string message) : base(message) { }

        public SyntaxParserException() : base("An error occurred during syntax parsing.") { }
    }
}
