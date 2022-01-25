using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.IO
{
    internal class IOManager
    {
        public IOManager(in ExecutionInstance instance)
        {
            ctx = instance;
            ctx.ThreadContext.Declare("stdout");
            ctx.ThreadContext["stdout"] = ulong.MaxValue;
        }

        private readonly ExecutionInstance ctx;

        public void Check()
        {
            if (ctx.ThreadContext["stdout"] != ulong.MaxValue)
            {
                ctx.Stdout(ctx.Strings[ctx.ThreadContext["stdout"]]);
                ctx.ThreadContext["stdout"] = ulong.MaxValue;
            }
        }
    }
}
