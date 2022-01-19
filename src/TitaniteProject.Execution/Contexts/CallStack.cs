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
            Frames = new List<CallStackFrame>
            {
                new CallStackFrame(0)
            };
        }

        public int Depth;
        readonly List<CallStackFrame> Frames;

        public CallStackFrame this[int index]
        {
            get { return Frames[index]; }
        }

        public CallStackFrame Current
        {
            get { return Frames[Depth]; }
        }

        public void Add(CallStackFrame frame)
            => Frames.Insert(++Depth, frame);

        public void Shed()
            => Frames.RemoveAt(--Depth);
    }
}
