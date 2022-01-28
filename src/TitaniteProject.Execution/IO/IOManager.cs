using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.IO
{
    internal class IOManager
    {
        public IOManager(in ExecutionInstance instance)
        {
            _ctx = instance;
            _plugins = new List<IOManagerPlugin>()
            {
                new StdoutPlugin()
            };

            foreach (IOManagerPlugin plugin in _plugins)
                plugin.Initialize(_ctx);
        }

        private readonly List<IOManagerPlugin> _plugins;

        private readonly ExecutionInstance _ctx;

        public void Install(IOManagerPlugin plugin)
        {
            _plugins.Add(plugin);
            _plugins[^0].Initialize(_ctx);
        }

        public void Check()
        {
            foreach (IOManagerPlugin plugin in _plugins)
                plugin.Check(_ctx);
        }
    }
}
