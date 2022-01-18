using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Contexts
{
    internal class VariableContext
    {
        public VariableContext()
        {
            globals = new Dictionary<string, string>();
        }

        private readonly Dictionary<string, string> globals;

        public string this[string alias]
        {
            get
            {
                return globals[alias];
            }

            set
            {
                if (globals.ContainsKey(alias))
                    globals[alias] = value;
                else
                    globals.Add(alias, value);
            }
        }
    }
}
