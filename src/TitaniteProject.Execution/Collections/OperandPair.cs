using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Collections
{
    internal struct OperandPair
    {
        public OperandPair(ulong left, ulong right)
        {
            Left = left;
            Right = right;
        }

        public readonly ulong Left;
        public readonly ulong Right;

        public ulong this[int index]
        {
            get
            {
                return index switch
                {
                    0 => Left,
                    1 => Right,
                    _ => throw new IndexOutOfRangeException()
                };
            }
        }
    }
}
