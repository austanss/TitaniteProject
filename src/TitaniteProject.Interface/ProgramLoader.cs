using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using TitaniteProject.Execution;
using TitaniteProject.Execution.Contexts;

namespace TitaniteProject.Interface
{
    public class ProgramLoader
    {
        public ProgramLoader()
        {
            configuration = new Dictionary<string, string>();
            LoadDefaultValues(ref configuration);
            used = false;
        }

        private Dictionary<string, string> configuration;
        private bool used;

        private void LoadDefaultValues(ref Dictionary<string, string> config)
        {
            if (used)
                throw new NotSupportedException("The caller function attempted to reference a loader instance that has been used.");

            config.Clear();

            config.Add("startup", "main.exe");
        }

        public ProgramLoader LoadConfiguration(string cfgFilePath)
        {
            if (used)
                throw new NotSupportedException("The caller function attempted to reference a loader instance that has been used.");

            LoadDefaultValues(ref configuration);

            FileStream cfg = File.OpenRead(cfgFilePath);

            if (cfg == null)
                throw new FileNotFoundException($"File \"{cfgFilePath}\" could not be loaded.");

            StreamReader sr = new(cfg);
            string[] modifiers = sr.ReadToEnd().Split("\n");
            sr.Dispose();
            cfg.Close();

            foreach (string modifier in modifiers)
            {
                string[] keyValuePair = modifier.Split('=');

                try { configuration[keyValuePair[0]] = keyValuePair[1].Replace("\r", "").Trim(); }
                catch (KeyNotFoundException)
                { throw new ArgumentOutOfRangeException($"The configuration file attempted to modify a value \"{keyValuePair[0]}\" that doesn't exist."); }
            }

            return this;
        }

        public ProgramPackage RetrieveProgram()
        {
            if (used)
                throw new NotSupportedException("The caller function attempted to reference a loader instance that has been used.");

            ProgramPackage program = new();
            program.CreateStreams();

            FileStream assembly;

            try { assembly = File.OpenRead(configuration["startup"]); }
            catch (Exception) { throw new FileLoadException($"The program \"{configuration["startup"]}\" could not be loaded."); }

            BinaryReader package = new(assembly);

            ulong signature = package.ReadUInt64();

            if (signature != 0x717A917E)
                throw new FileLoadException($"The program \"{configuration["startup"]}\" could not be loaded.");

            ulong codeOffset = package.ReadUInt64();
            ulong symbolsOffset = package.ReadUInt64();
            ulong stringsOffset = package.ReadUInt64();
            ulong manifestOffset = package.ReadUInt64();

            ulong codeSize = symbolsOffset - codeOffset;
            ulong symbolsSize = stringsOffset - symbolsOffset;
            ulong stringsSize = manifestOffset - stringsOffset;

            if (program.Code == null) throw new NullReferenceException("program.Code should not be null.");
            if (program.SymbolTable == null) throw new NullReferenceException("program.SymbolTable should not be null.");
            if (program.StringTable == null) throw new NullReferenceException("program.StringTable should not be null.");

            _ = package.BaseStream.Seek((long)codeOffset, SeekOrigin.Begin);
            package.BaseStream.CopyTo(program.Code, (int)codeSize);
            _ = package.BaseStream.Seek((long)symbolsOffset, SeekOrigin.Begin);
            package.BaseStream.CopyTo(program.SymbolTable, (int)symbolsSize);
            _ = package.BaseStream.Seek((long)stringsOffset, SeekOrigin.Begin);
            package.BaseStream.CopyTo(program.StringTable, (int)stringsSize);

            _ = package.BaseStream.Seek((long)manifestOffset, SeekOrigin.Begin);

            string manifest = package.ReadString();

            if (manifest == "content: null")
            {
                program.Name = "Program";
                program.Author = "Developer";
                program.Version = "1.0.0.0";
                program.Description = "An executable program.";

                configuration.Clear();
                used = true;
                return program;
            }

            string[] modifiers = manifest.Split('\n');

            foreach (string modifier in modifiers)
            {
                string[] keyValuePair = modifier.Split(':');

                try
                {
                    switch (keyValuePair[0])
                    {
                        case "name": program.Name = keyValuePair[1].Replace("\r", "").Trim(); break;

                        case "description": program.Description = keyValuePair[1].Replace("\r", "").Trim(); break;

                        case "author": program.Author = keyValuePair[1].Replace("\r", "").Trim(); break;

                        case "version": program.Version = keyValuePair[1].Replace("\r", "").Trim(); break;

                        default: throw new Exception();
                    }
                }
                catch { throw new FormatException("The manifest file is in an incorrect format."); }
            }

            configuration.Clear();
            used = true;
            return program;
        }
    }
}
