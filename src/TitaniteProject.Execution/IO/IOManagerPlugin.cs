using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.IO
{
    internal class IOManagerPlugin
    {
        protected IOManagerPlugin() { }

        public virtual void Initialize(in ExecutionInstance ctx) { }
        public virtual void Check(in ExecutionInstance ctx) { } 
    }
}
