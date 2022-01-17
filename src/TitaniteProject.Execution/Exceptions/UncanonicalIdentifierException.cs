using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Exceptions
{
    internal class UncanonicalIdentifierException : Exception
    {
        public const string CODE = "TE01";

        public UncanonicalIdentifierException() : base($"{CODE}: The identifier {"({undefined})"} is uncanonical.") { }

        public UncanonicalIdentifierException(string e) : base(e) { }
    }
}
