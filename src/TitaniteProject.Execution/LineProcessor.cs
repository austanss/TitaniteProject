using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution
{
    internal class LineProcessor
    {
        public LineProcessor(in ExecutionInstance ctx)
            => instance = ctx;

        private ExecutionInstance instance;

        public ExecutionStatus Process(string line)
        {
            if (line.StartsWith(';'))
                return ExecutionStatus.Normal;

            line = line.Trim().Replace("\r", "");

            if (line == "")
                return ExecutionStatus.Normal;

            string opcode = line.Substring(0, 3);
            string operand = line.Remove(0, 3).Trim();

            return instance.Instructions[opcode](operand);
        }
    }
}
