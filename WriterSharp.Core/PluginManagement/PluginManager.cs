using System;
using System.Collections.Generic;
using System.IO;
using WriterSharp.PluginAPI;
using WriterSharp.PluginAPI.Tools;


namespace WriterSharp.Core.PluginManagement
{

    public class PluginManager
    {

        private readonly List<IWriterSharpPlugin> loadedPlugins = new();
        private readonly PluginEventBus pluginEventBus = new();
        private readonly ILogger logger;

        public PluginManager(ILogger logger)
        {

            this.logger = logger;

        }

        public void LoadPlugins(string pluginFolder)
        {

            foreach (var directory in Directory.GetDirectories(pluginFolder))
            {

                if (directory is null) break; // we have no plugins to load
                if (!IsDirectoryPlugin(directory)) continue; // silently skip this

                LoadPlugin(directory);

            }

        }

        private void LoadPlugin(string directory)
        {

            // TODO: code this with black amgic
            throw new NotImplementedException("FML");

        }

		private static bool IsDirectoryPlugin(string directory)
		{

            // TODO: code this with black amgic
            return true;

		}

	}

}
