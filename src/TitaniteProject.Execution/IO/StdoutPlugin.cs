using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.IO
{
    internal class StdoutPlugin : IOManagerPlugin
    {
        public StdoutPlugin() { }

        private const string _STDOUT_LABEL = "stdout"; 

        public override void Initialize(in ExecutionInstance ctx) 
        {
            ctx.ThreadContext.Remove(_STDOUT_LABEL);
            ctx.ThreadContext.Declare(_STDOUT_LABEL);
            ctx.ThreadContext[_STDOUT_LABEL] = unchecked((ulong)-1);
        }

        public override void Check(in ExecutionInstance ctx) 
        {
            if (ctx.ThreadContext[_STDOUT_LABEL] != unchecked((ulong)-1))
                ctx.Stdout(ctx.Strings[ctx.ThreadContext[_STDOUT_LABEL]]);

            ctx.ThreadContext[_STDOUT_LABEL] = unchecked((ulong)-1);
        }
    }
}
