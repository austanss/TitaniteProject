using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Collections
{
    internal class RuntimeArray
    {
        public RuntimeArray(ulong reference, string identifier, int size)
        {
            Reference = reference;
            Identifier = identifier;
            SelectedElement = 0;
            _array = new ulong[size];
        }

        private readonly ulong[] _array;
        
        public readonly ulong Reference;
        public readonly string Identifier;

        public int SelectedElement;
        
        public ulong this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

    }
}
