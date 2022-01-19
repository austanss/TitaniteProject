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
            ctx.GlobalContext.Declare("stdout");
        }

        private readonly ExecutionInstance ctx;

        public void Check()
        {
            if (ctx.GlobalContext["stdout"] != "null")
            {
                ctx.Stdout(ctx.GlobalContext["stdout"]);
                ctx.GlobalContext["stdout"] = "null";
            }
        }
    }
}
