using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Contexts
{
    internal class VariableContext
    {
        public VariableContext()
            => globals = new Dictionary<string, string>();

        private readonly Dictionary<string, string> globals;

        public string this[string alias]
        {
            get { return globals[alias]; }

            set { globals[alias] = value; }
        }

        public void Declare(string alias)
            => globals.Add(alias, "null");

        public void Remove(string alias)
            => globals.Remove(alias);
    }
}
