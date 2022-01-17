using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using TitaniteProject.Execution;

namespace TitaniteProject.Runner
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

            config.Add("startup", "main.st");
            config.Add("manifest", "null");
        }

        public ProgramLoader LoadConfiguration(string cfgFilePath)
        {
            if (used)
                throw new NotSupportedException("The caller function attempted to reference a loader instance that has been used.");

            LoadDefaultValues(ref configuration);

            FileStream cfg = File.OpenRead(cfgFilePath);

            if (cfg == null)
                throw new FileNotFoundException($"File \"{cfgFilePath}\" could not be loaded.");

            StreamReader sr = new StreamReader(cfg);
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

        /// <summary>
        /// Retrieves the LoadedProgram object and effectively destroys the loader.
        /// </summary>
        public ProgramContext RetrieveProgram()
        {
            if (used)
                throw new NotSupportedException("The caller function attempted to reference a loader instance that has been used.");

            ProgramContext program = new ProgramContext();
            StreamReader sr;

            FileStream code;

            try { code = File.OpenRead(configuration["startup"]); }
            catch (Exception) { throw new FileLoadException($"The program \"{configuration["startup"]}\" could not be loaded."); }

            sr = new StreamReader(code);
            program.Content = sr.ReadToEnd();

            sr.Dispose();
            code.Dispose();

            if (configuration["manifest"] == "null")
                return program;

            FileStream manifest;

            try { manifest = File.OpenRead(configuration["manifest"]); }
            catch { throw new FileLoadException($"The specified manifest file \"{configuration["manifest"]}\""); }

            sr = new StreamReader(manifest);
            string[] modifiers = sr.ReadToEnd().Split("\n");

            sr.Dispose();
            manifest.Dispose();

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
