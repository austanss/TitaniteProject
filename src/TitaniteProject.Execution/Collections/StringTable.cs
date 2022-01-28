using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Collections
{
    internal class StringTable
    {
        public StringTable()
            => _strings = new Dictionary<ulong, string>();

        public string this[ulong id]
        {
            get => _strings[id];
            set => _strings[id] = value;
        }

        public ulong ReadOnlyLimit;

        public void Register(ulong id, string value)
            => _strings.Add(id, value);

        private readonly Dictionary<ulong, string> _strings;
    }
}
