using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Contexts
{
    internal class CallStack
    {
        public CallStack()
        {
            Depth = 0;
            Frames = new List<CallStackFrame>();
        }

        public ulong Depth;
        List<CallStackFrame> Frames;
    }
}
