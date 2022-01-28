using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Collections
{
    internal class SymbolTable
    {
        public SymbolTable()
            => _symbols = new Dictionary<ulong, ulong>();

        public ulong this[ulong id]
        {
            get => _symbols[id];
            set => _symbols[id] = value;
        }

        public void Register(ulong index, ulong offset)
            => _symbols.Add(index, offset);

        private readonly Dictionary<ulong, ulong> _symbols;
    }
}
