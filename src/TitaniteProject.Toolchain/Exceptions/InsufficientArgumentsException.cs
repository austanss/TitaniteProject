using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitaniteProject.Toolchain.Exceptions
{
    internal class InsufficientArgumentsException : ToolchainException
    {
        public InsufficientArgumentsException(string message) : base(message) { }
        
        public InsufficientArgumentsException() : base("Not enough arguments were supplied to the toolchain.") { }

        public override void Throw(string message) { throw new InsufficientArgumentsException(message); }
    }
}
