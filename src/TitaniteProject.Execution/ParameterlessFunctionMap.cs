using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution
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
