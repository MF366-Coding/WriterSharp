using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using WriterSharp.PluginAPI;
using WriterSharp.PluginAPI.Tools;
using WriterSharp.Core.ErrorManagement;
using System.Security;


namespace WriterSharp.Core.PluginManagement
{

	public class PluginManager
	{

		private readonly List<IWriterSharpPlugin> loadedPlugins = new();
		// todo: private readonly PluginEventBus pluginEventBus = new();
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

			string path = Path.Join(directory, "EntryPoint.Plugin.dll");

			if (!File.Exists(path))
				return false;

			Assembly? assembly = null;

			try
			{

				assembly = Assembly.LoadFrom(path);

			}
			catch (FileNotFoundException fEx)
			{

				ErrorCache.RegisterError(new PluginError(Path.GetFileName(directory) ?? "NoPluginFound", 1, $"Could not find a WriterSharp plugin at {directory}.", fEx));
				return false;

			}
			catch (FileLoadException flEx)
			{

				ErrorCache.RegisterError(new PluginError(Path.GetFileName(directory), 2, $"Failed to load existing file at {path}.", flEx));
				return false;

			}
			catch (BadImageFormatException badIFEx)
			{

				ErrorCache.RegisterError(new PluginError(Path.GetFileName(directory), 2, $"Plugin at {path} is incompatible with the currently loaded assembly.", badIFEx));
				return false;

			}
			catch (SecurityException secEx)
			{

				ErrorCache.RegisterError(new PluginError(Path.GetFileName(directory), 3, $"Missing the required WebPermission to be able to access plugin at {path}.", secEx));
				return false;

			}
			catch (PathTooLongException ptlEx)
			{

				ErrorCache.RegisterError(new PluginError(Path.GetFileName(directory), 4, $"Path to plugin (ends with {path.AsSpan(path.Length - 20, 20)}) exceeds system-defined maximum in character count.", ptlEx));
				return false;

			}
			catch (Exception ex)
			{

				ErrorCache.RegisterError(new PluginError(Path.GetFileName(directory), 5, $"Unknown error when loading plugin at {path}.", ex));
				return false;

			}


			if (assembly is null)
			{

				// todo
				return false;

			}

			var pluginType = assembly.GetTypes().ToList().
				FirstOrDefault(t => typeof(IWriterSharpPlugin).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

			return true; // todo

		}

	}

}
