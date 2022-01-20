using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Contexts
{
    internal class VariableContext
    {
        public VariableContext()
            => variables = new Dictionary<string, ulong>();

        private readonly Dictionary<string, ulong> variables;

        public ulong this[string identifier]
        {
            get { return variables[identifier]; }

            set { variables[identifier] = value; }
        }

        public void Declare(string identifier)
            => variables.Add(identifier, 0);

        public void Remove(string identifier)
            => variables.Remove(identifier);

        public bool Contains(string identifier)
            => variables.ContainsKey(identifier);
    }
}
