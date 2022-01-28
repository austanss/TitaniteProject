using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Collections
{
    internal class ArrayCollection
    {
        public ArrayCollection()
        {
            _arrays = new Dictionary<ulong, RuntimeArray>();
        }

        private readonly Dictionary<ulong, RuntimeArray> _arrays;

        public RuntimeArray this[ulong index]
        {
            get => _arrays[index];
        }

        public ulong Create(string identifier, int size)
        {
            ulong reference;

            for (reference = 0; reference < ulong.MaxValue; reference++)
                if (!_arrays.ContainsKey(reference))
                    break;

            RuntimeArray array = new RuntimeArray(reference, identifier, size);

            _arrays.Add(reference, array);

            return reference;
        }

        public void Destroy(ulong reference)
            => _ = _arrays.Remove(reference);
    }
}
