using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Functions
{
    internal class UserDefinedFunction : RuntimeFunction
    {
        public UserDefinedFunction(ulong line)
        {
            this.line = line;
            List.TryAdd(line, this);
        }

        private ulong line;
        public static Dictionary<ulong, UserDefinedFunction> List = new Dictionary<ulong, UserDefinedFunction>();

        public override ExecutionStatus Invoke(in ExecutionInstance ctx)
        {
            ctx.Counter = line;
            return ExecutionStatus.Normal;
        }
    }
}
