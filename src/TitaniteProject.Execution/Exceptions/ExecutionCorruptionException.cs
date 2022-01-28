using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Exceptions
{
    internal class ExecutionCorruptionException : Exception
    {
        public const string CODE = "TE-002";

        public ExecutionCorruptionException(string message) : base(message) { }

        public ExecutionCorruptionException() : base($"{CODE}: The execution environment was corrupted and unexpected behavior occurred.") { }
    }
}
