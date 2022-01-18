using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution.Functions
{
    internal class PutStringFunction : RuntimeFunction
    {
        public override ExecutionStatus Invoke(in ExecutionInstance ctx)
        {
            ctx.Stdout(ctx.GlobalContext["conout"]);
            return ExecutionStatus.Normal;
        }
    }
}
