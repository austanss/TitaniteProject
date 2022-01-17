using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Exceptions
{
    internal class ExecutionCorruptionException : Exception
    {
        public const string CODE = "TE02";

        public ExecutionCorruptionException(string message) : base(message) { }

        public ExecutionCorruptionException() : base($"{CODE}: The execution environment was corrupted and unexpected behavior occurred.") { }
    }
}
