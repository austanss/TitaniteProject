using System;
using System.Collections.Generic;
using System.Text;

using TitaniteProject.Execution.Contexts;
using TitaniteProject.Execution.Exceptions;

namespace TitaniteProject.Execution.Preliminary
{
    internal class FunctionSweep
    {
        public FunctionSweep(ProgramContext program)
        {
            code = program.Content.Split("\n");
            
            detectedPositions = new List<ulong>();

            for (ulong i = 0; i < (ulong)code.Length; i++)
            {
                string line = code[i];

                line = line.Replace("\r", "").Trim();

                if (line.StartsWith("fnc"))
                {
                    UncanonicalIdentifierException.Check(line[4..(line.Length-1)]);
                    detectedPositions.Add(i);
                }
            }
        }

        private readonly string[] code;

        private readonly List<ulong> detectedPositions;

        public ulong[] Catalyze()
        {
            return detectedPositions.ToArray();
        }
    }
}
