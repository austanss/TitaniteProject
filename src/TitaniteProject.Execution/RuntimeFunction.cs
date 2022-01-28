using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution
{
    internal class RuntimeFunction
    {
        protected RuntimeFunction() { }

        public virtual ExecutionStatus Invoke(in ExecutionInstance ctx) { return ExecutionStatus.Corrupted; }
    }
}
