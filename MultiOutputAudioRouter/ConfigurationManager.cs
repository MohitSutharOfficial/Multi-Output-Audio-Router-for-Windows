using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MultiOutputAudioRouter
{
    /// <summary>
    /// Manages application configuration and user preferences
    /// </summary>
    public class ConfigurationManager
    {
        private static readonly string ConfigFileName = "config.json";
        private static readonly string ConfigDirectory = 
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
                        "MultiOutputAudioRouter");
        private static readonly string ConfigFilePath = Path.Combine(ConfigDirectory, ConfigFileName);

        public class Configuration
        {
            public List<string> SelectedDeviceIds { get; set; } = new List<string>();
            public bool AutoStartRouting { get; set; } = false;
            public DateTime LastSaved { get; set; } = DateTime.Now;
        }

        /// <summary>
        /// Loads configuration from disk
        /// </summary>
        public static Configuration LoadConfiguration()
        {
            try
            {
                if (!File.Exists(ConfigFilePath))
                {
                    return new Configuration();
                }

                var json = File.ReadAllText(ConfigFilePath);
                var config = JsonSerializer.Deserialize<Configuration>(json);
                return config ?? new Configuration();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading configuration: {ex.Message}");
                return new Configuration();
            }
        }

        /// <summary>
        /// Saves configuration to disk
        /// </summary>
        public static void SaveConfiguration(Configuration config)
        {
            try
            {
                // Ensure directory exists
                if (!Directory.Exists(ConfigDirectory))
                {
                    Directory.CreateDirectory(ConfigDirectory);
                }

                config.LastSaved = DateTime.Now;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                var json = JsonSerializer.Serialize(config, options);
                File.WriteAllText(ConfigFilePath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving configuration: {ex.Message}");
            }
        }

        /// <summary>
        /// Clears saved configuration
        /// </summary>
        public static void ClearConfiguration()
        {
            try
            {
                if (File.Exists(ConfigFilePath))
                {
                    File.Delete(ConfigFilePath);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error clearing configuration: {ex.Message}");
            }
        }
    }
}
