using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using WriterSharp.PluginAPI;
using WriterSharp.PluginAPI.Tools;
using WriterSharp.Core.ErrorManagement;
using System.Security;
using WriterSharp.Core.PluginAPI;


namespace WriterSharp.Core.PluginManagement
{

	public class PluginManager
	{

		/// <summary>
		/// Contains all the currently loaded plugins.
		/// </summary>
		private readonly List<IWriterSharpPlugin> loadedPlugins = new();

		// todo: private readonly PluginEventBus pluginEventBus = new();

		/// <summary>
		/// The logger.
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// Instantiates the plugin manager with a logger.
		/// </summary>
		/// <param name="logger">The logger to use</param>
		public PluginManager(ILogger logger)
		{

			this.logger = logger;

		}

		public void LoadPlugins(string pluginFolder)
		{

			Type? currentAssembly = null;

			foreach (var directory in Directory.GetDirectories(pluginFolder))
			{

				if (directory is null) break; // we have no plugins to load
				currentAssembly = GetEntryPointIfDirectoryContainsPlugin(directory);

				if (currentAssembly is null) continue; // just skip past this piece of shit

				LoadPlugin(currentAssembly);

			}

		}

		private void LoadPlugin(Type pluginType)
		{

			var plugin = (IWriterSharpPlugin)Activator.CreateInstance(pluginType)!;
			IPluginAPI? api;

			switch (plugin.PreferedPluginAPIVersion)
			{

				// todo: add more cases later

				default:
					api = new PluginAPIv1(logger);
					break;

			}

			plugin.Initialize(api);

		}

		/// <summary>
		/// Checks if a directory is a plugin directory and returns an entry point class for that plugin if so.
		/// </summary>
		/// <param name="directory">The directory to check.</param>
		/// <returns>An entry point class or null (in case the directory doesn't have a plugin)</returns>
		private static Type? GetEntryPointIfDirectoryContainsPlugin(string directory)
		{

			string path = Path.Join(directory, "EntryPoint.Plugin.dll");

			if (!File.Exists(path))
			{

				return null;

			}

			Assembly? assembly = null;

			try
			{

				assembly = Assembly.LoadFrom(path);

			}
			catch (FileNotFoundException fEx)
			{

				ErrorCache.RegisterError(new PluginError(Path.GetFileName(directory) ?? "NoPluginFound", 1, $"Could not find a WriterSharp plugin at {directory}.", fEx));
				return null;

			}
			catch (FileLoadException flEx)
			{

				ErrorCache.RegisterError(new PluginError(Path.GetFileName(directory), 2, $"Failed to load existing file at {path}.", flEx));
				return null;

			}
			catch (BadImageFormatException badIFEx)
			{

				ErrorCache.RegisterError(new PluginError(Path.GetFileName(directory), 2, $"Plugin at {path} is incompatible with the currently loaded assembly.", badIFEx));
				return null;

			}
			catch (SecurityException secEx)
			{

				ErrorCache.RegisterError(new PluginError(Path.GetFileName(directory), 3, $"Missing the required WebPermission to be able to access plugin at {path}.", secEx));
				return null;

			}
			catch (PathTooLongException ptlEx)
			{

				ErrorCache.RegisterError(new PluginError(Path.GetFileName(directory), 4, $"Path to plugin (ends with {path.AsSpan(path.Length - 20, 20)}) exceeds system-defined maximum in character count.", ptlEx));
				return null;

			}
			catch (Exception ex)
			{

				ErrorCache.RegisterError(new PluginError(Path.GetFileName(directory), 5, $"Unknown error when loading plugin at {path}.", ex));
				return null;

			}


			if (assembly is null)
			{

				ErrorCache.RegisterError(new PluginError(Path.GetFileName(directory), 5, $"Unknown error when loading plugin at {path}.", ex));
				return null;

			}

			var pluginType = assembly
				.GetTypes() // gets ze types a.k.a. classes
				.ToList() // turns this into a list cuz arrays suck ass
				.FirstOrDefault
				(

					t => typeof(IWriterSharpPlugin). // check if something inherits from IWriterSharpPlugin
													IsAssignableFrom(t) // and is a class
																		&& !t.IsInterface // and is not an interface
																						&& !t.IsAbstract // and god forbid it being an abstract class
																										 // or as I like to call them, wannabe interfaces


				);

			if (pluginType is null)
			{

				ErrorCache.RegisterError(new PluginError(Path.GetFileName(directory), 6, $"Plugin at {path} is invalid: could not parse an instantiable class deriving from IWriterSharpPlugin.", null));
				return null;

			}

			return pluginType;

		}

	}

}
