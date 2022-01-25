using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Execution.Collections
{
    internal class FunctionMap<TKey, TArgument>
    {
        public FunctionMap()
        {
            map = new Dictionary<TKey, Func<TArgument, ExecutionStatus>>();
        }

        private readonly Dictionary<TKey, Func<TArgument, ExecutionStatus>> map;

        public void Clear()
            => map.Clear();

        public void Register(TKey key, Func<TArgument, ExecutionStatus> function)
            => map.Add(key, function);

        public Func<TArgument, ExecutionStatus> this[TKey key]
        {
            get 
            { 
                return map[key]; 
            }
        }
    }
}
