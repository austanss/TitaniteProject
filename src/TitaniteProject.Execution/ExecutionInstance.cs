using System;
using System.IO;
using System.Collections.Generic;

using TitaniteProject.Execution.Exceptions;
using TitaniteProject.Execution.Contexts;
using TitaniteProject.Execution.Collections;
using TitaniteProject.Execution.Instructions;
using TitaniteProject.Execution.IO;

namespace TitaniteProject.Execution
{
    public delegate void StandardOutput(string conout);

    public class ExecutionInstance
    {
        internal StandardOutput Stdout;

        internal ProgramPackage Program;

        internal FunctionMap<byte, OperandPair> Instructions;

        internal VariableContext ThreadContext;
        internal VariableContext LocalContext;

        internal CallStack CallStack;

        internal StringTable Strings;
        internal SymbolTable Symbols;

        internal IOManager IO;

        internal ulong InstructionPointer
        {
            get => (ulong)Program.Code.Position;
            set => Program.Code.Seek((long)value, SeekOrigin.Begin);
        }

        public ExecutionInstance(ProgramPackage program, StandardOutput stdout)
        {
            Program = program;
            Stdout = stdout;

            Instructions = new FunctionMap<byte, OperandPair>();

            Instructions = GenerateInstructionMap(Instructions);

            CallStack = new CallStack();

            LocalContext = CallStack.Current.LocalVariables;
            ThreadContext = new VariableContext();

            Strings = ParseStringTable(new StringTable());
            Symbols = ParseSymbolTable(new SymbolTable());

            IO = new IOManager(this);

            InstructionPointer = 0;
        }

        private FunctionMap<byte, OperandPair> GenerateInstructionMap(in FunctionMap<byte, OperandPair> map)
        {
            map.Clear();
            map.Register(0x01, (OperandPair operands) => Instruction.Define.Execute(operands, this));
            map.Register(0x02, (OperandPair operands) => Instruction.Set.Execute(operands, this));
            map.Register(0x03, (OperandPair operands) => Instruction.Write.Execute(operands, this));
            map.Register(0x04, (OperandPair operands) => Instruction.Read.Execute(operands, this));
            map.Register(0x05, (OperandPair operands) => Instruction.Jump.Execute(operands, this));
            map.Register(0x06, (OperandPair operands) => Instruction.Return.Execute(operands, this));
            map.Register(0x07, (OperandPair operands) => Instruction.None.Execute(operands, this));
            map.Register(0x08, (OperandPair operands) => Instruction.Split.Execute(operands, this));
            map.Register(0x09, (OperandPair operands) => Instruction.Select.Execute(operands, this));
            map.Register(0x0A, (OperandPair operands) => Instruction.Add.Execute(operands, this));
            map.Register(0x0B, (OperandPair operands) => Instruction.Subtract.Execute(operands, this));
            map.Register(0x0C, (OperandPair operands) => Instruction.Multiply.Execute(operands, this));
            map.Register(0x0D, (OperandPair operands) => Instruction.Divide.Execute(operands, this));
            return map;
        }

        private SymbolTable ParseSymbolTable(in SymbolTable table)
        {
            BinaryReader reader = new BinaryReader(Program.SymbolTable);
            _ = reader.BaseStream.Seek(0, SeekOrigin.Begin);

            ulong length = reader.ReadUInt64();

            ulong index = 0;

            while (index < length)
            {
                _ = reader.ReadString();

                table.Register(index, reader.ReadUInt64());

                index++;
            }

            return table;
        }

        private StringTable ParseStringTable(in StringTable table)
        {
            BinaryReader reader = new BinaryReader(Program.StringTable);
            _ = reader.BaseStream.Seek(0, SeekOrigin.Begin);

            ulong length = reader.ReadUInt64();

            ulong index = 0;

            while (index < length)
            {
                string value = reader.ReadString();

                if (value == "")
                    break;

                if (value[0] == '"')
                {
                    value = value.Remove(0, 1);
                    value = value.Remove(value.Length - 1, 1);
                }

                table.Register(reader.ReadUInt64(), value);

                index++;
            }

            table.ReadOnlyLimit = index;

            return table;
        }

        public void Run()
        {
            InstructionProcessor processor = new InstructionProcessor(this);

            ExecutionStatus status = ExecutionStatus.Normal;

            _ = Program.Code.Seek(0, SeekOrigin.Begin);
            BinaryReader head = new BinaryReader(Program.Code);

            while (status == ExecutionStatus.Normal)
            {
                IO.Check();

                InstructionData instruction = new InstructionData
                {
                    Opcode = head.ReadByte(),
                    Operands = new OperandPair(head.ReadUInt64(), head.ReadUInt64())
                };

                status = processor.Process(instruction);
            }

            if (status == ExecutionStatus.EndOfProgram)
                return;

            if (status == ExecutionStatus.Corrupted)
                throw new ExecutionCorruptionException();

            if (status == ExecutionStatus.Normal)
                throw new ExecutionCorruptionException($"{ExecutionCorruptionException.CODE}: The execution loop was exited unexpectedly.");

            if (status == ExecutionStatus.InvalidInstruction || status == ExecutionStatus.InvalidOperands)
                throw new InvalidOpcodeException($"{InvalidOpcodeException.CODE}: The loaded assembly contains an invalid opcode at byte ${InstructionPointer}");
        }
    }
}
