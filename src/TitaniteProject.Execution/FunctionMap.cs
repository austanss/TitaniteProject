using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution
{
    internal class FunctionMap<T>
    {
        public FunctionMap()
        {
            map = new Dictionary<string, Func<T, ExecutionStatus>>();
        }

        private readonly Dictionary<string, Func<T, ExecutionStatus>> map;

        public void Clear()
            => map.Clear();

        public void Register(string key, Func<T, ExecutionStatus> function)
            => map.Add(key, function);

        public Func<T, ExecutionStatus> this[string key]
        {
            get 
            { 
                return map[key]; 
            }
        }
    }
}
