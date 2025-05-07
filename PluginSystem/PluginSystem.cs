/*
 *  ___   _                 _            ___               _                 
 * | _ \ | |  _  _   __ _  (_)  _ _     / __|  _  _   ___ | |_   ___   _ __  
 * |  _/ | | | || | / _` | | | | ' \    \__ \ | || | (_-< |  _| / -_) | '  \ 
 * |_|   |_|  \_,_| \__, | |_| |_||_|   |___/  \_, | /__/  \__| \___| |_|_|_|
 *                  |___/                      |__/                 
 *                  
 * MIT License * MF366
 *                  
 */


// System
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Avalonia.Win32.Interop.Automation;


namespace WriterSharp
{

	/// <summary>
	/// Interface for translation datapacks.
	/// </summary>
	public interface ITranslation
	{

		/// <summary>
		/// The name of the plugin that manages this translation.
		/// </summary>
		public string PluginName { get; set; }

		/// <summary>
		/// The actual translation itself, as a dictionary.
		/// </summary>
		protected Dictionary<string, string> Translation { get; set; }

		/// <summary>
		/// Assign or access a translation key.
		/// </summary>
		/// <param name="key">The translation entry to access/modify</param>
		/// <returns><strong>(get)</strong> Returns the matching entry or null if none was found</returns>
		/// <exception cref="ArgumentNullException">Cannot assign an entry to null</exception>
		public string? this[string key]
		{

			get => Translation.GetValueOrDefault(key);
			set
			{

				if (value is null) throw new ArgumentNullException(nameof(value), "Value to assign may not be null");
				else Translation.Add(key, value);

			}

		}

	}

	/// <summary>
	/// Interface for syntax highlighting themes.
	/// </summary>
	public interface ISyntaxColormap
	{

		/// <summary>
		/// The name of the plugin that manages this colormap.
		/// </summary>
		public string PluginName { get; set; }

		/// <summary>
		/// The actual colormap itself, as a dictionary.
		/// </summary>
		protected Dictionary<string, string> Colormap { get; set; }

		/// <summary>
		/// Assign or access a colormap key.
		/// </summary>
		/// <param name="key">The colormap entry to access/modify</param>
		/// <returns><strong>(get)</strong> Returns the matching entry or null if none was found</returns>
		/// <exception cref="ArgumentNullException">Cannot assign an entry to null</exception>
		public string? this[string key]
		{

			get => Colormap.GetValueOrDefault(key);
			set
			{

				if (value is null) throw new ArgumentNullException(nameof(value), "Value to assign may not be null");
				else Colormap.Add(key, value);

			}

		}

	}

	public struct WriterSharpPlugin
	{

		/// <summary>
		/// Plugin name.
		/// </summary>
		string name;

		/// <summary>
		/// Translations.
		/// </summary>
		ITranslation[] translations;

		/// <summary>
		/// Colormaps.
		/// </summary>
		ISyntaxColormap[] colormaps;

	}

	public static class PluginLoader
	{

		public static void LoadPlugin(string directoryName, out WriterSharpPlugin? plugin)
		{

			if (!Path.Exists(directoryName) || !Path.Exists(Path.Join(directoryName, "Plugin.xml"))) throw new ArgumentException("Invalid directory name - directory does not exist or does not contain plugins.");

			plugin = null; // todo: placeholder

		}

		internal static bool IsPluginSupported(string requiredVersion)
		{

			if (requiredVersion.Equals("any")) return true;

			if (requiredVersion.Length < 7) return false; // version is invalid, plugin is unsupported

			var mode = requiredVersion.AsSpan(0, 2);
			var version = requiredVersion.AsSpan(2);
			var versionAsArray = version.ToString().Split('.');

			short myMajor = Convert.ToInt16(Constants.AppVersionAsArray[0]);
			short myMinorValue = Convert.ToInt16(Constants.AppVersionAsArray[1]);
			short myPatch = Convert.ToInt16(Constants.AppVersionAsArray[2]);

			short major;
			short minor;
			short patch;

			try
			{

				major = Convert.ToInt16(versionAsArray[0]);
				minor = Convert.ToInt16(versionAsArray[1]);
				patch = Convert.ToInt16(versionAsArray[2]);

			}
			catch (FormatException) { return false; } // unsupported cuz shity plugin dev
			catch (OverflowException) { return false; } // version do be huge

			switch (mode)
			{

				case "==":
					// equality
					return version == Constants.AppVersion;

				case "!=":
					return version != Constants.AppVersion;

				case ">>":
					// greater
					if (major > myMajor) return false;
					if (major < myMajor) return true;

					if (minor > myMinorValue) return false;
					if (minor < myMinorValue) return true;

					return patch < myPatch;

				case "<<":
					// lower
					if (major < myMajor) return false;
					if (major > myMajor) return true;

					if (minor < myMinorValue) return false;
					if (minor > myMinorValue) return true;

					return patch > myPatch;

			}

			return false; // todo: placeholder

		}

		public static void InterpretPluginXML(XmlDocument xmlDocument, out WriterSharpPlugin? plugin)
		{

			var root = xmlDocument.DocumentElement;
			if (root is null) { plugin = null; return; }

			string? pluginInnerName = root.Attributes["InnerName"]?.Value;
			if (pluginInnerName is null) { plugin = null; return; }

			string pluginName = root.Attributes["Name"]?.Value ?? pluginInnerName;

			string pluginRequiresVersion = root.Attributes["RequiresEngineVersion"]?.Value ?? "any";

			if (!IsPluginSupported(pluginRequiresVersion)) { plugin = null; return; }

			plugin = null; // TODO: placeholder

		}

	}

}

