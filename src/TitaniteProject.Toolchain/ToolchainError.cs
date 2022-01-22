using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TitaniteProject.Toolchain.Exceptions;

namespace TitaniteProject.Toolchain
{
    internal static class ToolchainError
    {
        public static readonly ToolchainError<CompilationInitiationException> TC0001 = new("TC0001", "An internal error occurred, causing compilation contexts to be nullified.");

    }

    internal class ToolchainError<TException> where TException : ToolchainException, new()
    {
        internal ToolchainError(string code, string message)
            => Message = $"{code}: {message}";

        public string Message { get; }

        public void Throw()
        {
            Console.WriteLine($"ERROR: {Message} [{typeof(TException).Name}]");
            Environment.Exit(-1);
        }
    }
}
