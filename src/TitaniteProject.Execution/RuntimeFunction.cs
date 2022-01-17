using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution
{
    internal class RuntimeFunction
    {
        protected RuntimeFunction() { }

        public virtual ExecutionStatus Invoke(in ExecutionInstance ctx) { return ExecutionStatus.Corrupted; }

        public static RuntimeFunction PutString = new Functions.PutStringFunction();
    }
}
