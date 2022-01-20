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
            LocalVariables = new VariableContext();
        }

        public ulong ReturnPosition;
        public VariableContext LocalVariables;
    }
}
