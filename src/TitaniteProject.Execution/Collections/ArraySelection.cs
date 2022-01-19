using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Collections
{
    internal class ArraySelection<T>
    {
        public ArraySelection(T[] source, ulong[] indices)
        {
            selection = new List<T>();

            for (int i = 0; i < indices.Length; i++)
                selection.Add(source[indices[i]]);
        }

        private readonly List<T> selection;

        public T[] Catalyze()
        {
            return selection.ToArray();
        }
    }
}
