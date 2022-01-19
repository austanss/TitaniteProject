using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution
{
    internal class UserDefinedFunction : RuntimeFunction
    {
        public UserDefinedFunction(string identifier, ulong line)
        {
            this.line = line;
            List.TryAdd(identifier, this);
        }

        private readonly ulong line;

        public static Dictionary<string, UserDefinedFunction> List = new Dictionary<string, UserDefinedFunction>();

        public override ExecutionStatus Invoke(in ExecutionInstance ctx)
        {
            ctx.Counter = line;
            return ExecutionStatus.Normal;
        }
    }
}
