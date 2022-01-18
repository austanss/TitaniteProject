using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Contexts
{
    internal enum ExecutionStatus : byte
    {
        Normal = 000,
        InvalidInstruction = 001,
        InvalidOperands = 002,
        InvalidContext = 003,
        Corrupted = 004,
        EndOfProgram = 005
    }
}
