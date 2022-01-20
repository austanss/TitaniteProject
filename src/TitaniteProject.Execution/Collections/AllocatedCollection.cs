using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Collections
{
    internal class AllocatedCollection<T>
    {
        public AllocatedCollection()
        {
            FastIndex = 0;
            Items = new Dictionary<int, T>(); 
        }

        int FastIndex;
        readonly Dictionary<int, T> Items;

        public int Add(T item)
        {
            if (Items.ContainsKey(FastIndex))
            {
                int pos;
                for (pos = 0 ;; pos++)
                    if (!Items.ContainsKey(pos))
                        break;

                FastIndex = pos;
            }

            Items.Add(FastIndex, item);
            return FastIndex++;
        }

        public void Remove(int id)
            => Items.Remove(id);

        public T this[int id]
        {
            get { return Items[id]; }
            set { Items[id] = value; }
        }
    }
}
