using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Contexts
{
    internal class CallStackFrame
    {
        public CallStackFrame(ulong returnPosition)
        {
            ReturnPosition = returnPosition;
            LocalVariableIdentifiers = new List<string>();
        }

        public ulong ReturnPosition;
        public List<string> LocalVariableIdentifiers;
    }
}
