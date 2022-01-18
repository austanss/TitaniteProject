using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution.Collections
{
    internal class ParameterlessFunctionMap
    {
        public ParameterlessFunctionMap()
        {
            map = new Dictionary<string, Func<ExecutionStatus>>();
        }

        private readonly Dictionary<string, Func<ExecutionStatus>> map;

        public void Clear()
            => map.Clear();

        public void Register(string key, Func<ExecutionStatus> function)
            => map.Add(key, function);

        public Func<ExecutionStatus> this[string key]
        {
            get 
            { 
                return map[key]; 
            }
        }
    }
}
