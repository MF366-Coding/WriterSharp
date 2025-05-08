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
using System.Threading.Tasks;
using System.Xml;

// Dependencies
using TextMateSharp.Grammars;


namespace WriterSharp
{

	/// <summary>
	/// Interface for translation datapacks.
	/// </summary>
	public class WriterSharpTranslation
	{

		/// <summary>
		/// The name of the plugin that manages this translation.
		/// </summary>
		public string PluginName { get; set; }

		/// <summary>
		/// English name (0) and Actual Name (1).
		/// </summary>
		public string[] TranslationNames { get; set; }

		/// <summary>
		/// The actual translation itself, as a dictionary.
		/// </summary>
		protected Dictionary<string, string>? Translation { get; set; }

		/// <summary>
		/// Assign or access a translation key.
		/// </summary>
		/// <param name="key">The translation entry to access/modify</param>
		/// <returns><strong>(get)</strong> Returns the matching entry or null if none was found</returns>
		/// <exception cref="ArgumentNullException">Cannot assign an entry to null</exception>
		public string? this[string key]
		{

			get => Translation?.GetValueOrDefault(key);
			set
			{

				if (Translation is null) return;
				if (value is null) throw new ArgumentNullException(nameof(value), "Value to assign may not be null");
				else Translation.Add(key, value);

			}

		}

		public WriterSharpTranslation(string plugin, string englishName, string realName, string translationFile)
		{

			PluginName = plugin;
			TranslationNames = [englishName, realName];
			// todo: work on dis

		}

	}

	/// <summary>
	/// Interface for syntax highlighting themes.
	/// </summary>
	public class SyntaxColormap
	{

		/// <summary>
		/// The name of the plugin that manages this colormap.
		/// </summary>
		public string PluginName { get; set; }

		/// <summary>
		/// The mode this theme supports (use Auto for any).
		/// </summary>
		public WriterSharpTheme ThemeMode { get; set; }

		/// <summary>
		/// The actual colormap itself, as a dictionary.
		/// </summary>
		protected Dictionary<string, string>? Colormap { get; set; }

		public SyntaxColormap(string plugin, WriterSharpTheme theme, string colormapFile)
		{

			PluginName = plugin;
			ThemeMode = theme;
			// todo: work on dis

		}

		/// <summary>
		/// Assign or access a colormap key.
		/// </summary>
		/// <param name="key">The colormap entry to access/modify</param>
		/// <returns><strong>(get)</strong> Returns the matching entry or null if none was found</returns>
		/// <exception cref="ArgumentNullException">Cannot assign an entry to null</exception>
		public string? this[string key]
		{

			get => Colormap?.GetValueOrDefault(key);
			set
			{

				if (Colormap is null) return;
				if (value is null) throw new ArgumentNullException(nameof(value), "Value to assign may not be null");
				else Colormap.Add(key, value);

			}

		}

	}

	/// <summary>
	/// Interface for WriterSharp languages.
	/// </summary>
	public class Language
	{

		/// <summary>
		/// The name of the plugin that manages this language.
		/// </summary>
		public string PluginName { get; set; }

		/// <summary>
		/// The name of this language.
		/// </summary>
		public string LanguageName { get; set; }

		/// <summary>
		/// The grammar/syntax for this language.
		/// </summary>
		public Grammar? Grammar { get; set; }

		// todo
		public Language(string plugin, string language, string grammarFile)
		{

			PluginName = plugin;
			LanguageName = language;
			// todo: work on dis

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
		WriterSharpTranslation[] translations;

		/// <summary>
		/// Colormaps.
		/// </summary>
		SyntaxColormap[] colormaps;

	}

	public static class PluginLoader
	{

		public static void LoadPlugin(string directoryName, out WriterSharpPlugin? plugin)
		{

			if (!Path.Exists(directoryName) || !Path.Exists(Path.Join(directoryName, "Plugin.xml"))) throw new ArgumentException("Invalid directory name - directory does not exist or does not contain plugins.");

			plugin = null; // todo: placeholder

		}

		/// <summary>
		/// Checks if a plugin is supported by the current version of WriterSharp.
		/// </summary>
		/// <param name="requiredVersion">The required version, as a string</param>
		/// <returns>A boolean (is supported?)</returns>
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

				case ">=":
					// greater or equal
					if (major > myMajor) return false;
					if (major <= myMajor) return true;

					if (minor > myMinorValue) return false;
					if (minor <= myMinorValue) return true;

					return patch <= myPatch;

				case "<=":
					// lower or equal
					if (major < myMajor) return false;
					if (major >= myMajor) return true;

					if (minor < myMinorValue) return false;
					if (minor >= myMinorValue) return true;

					return patch >= myPatch;

				default:
					return false;

			}

		}

		private static Task HandlePluginLanguages(XmlNodeList languages)
		{

			throw new NotImplementedException("TODO"); // todo

		}

		public static void InterpretPluginXML(XmlDocument xmlDocument, out WriterSharpPlugin? plugin)
		{

			var root = xmlDocument.DocumentElement;
			if (root is null) { plugin = null; return; }

			string? pluginInnerName = root.Attributes["InnerName"]?.Value;
			if (pluginInnerName is null) { plugin = null; return; }
			// todo: innername must be unique		

			string pluginName = root.Attributes["Name"]?.Value ?? pluginInnerName;

			string pluginRequiresVersion = root.Attributes["RequiresEngineVersion"]?.Value ?? "any";

			if (!IsPluginSupported(pluginRequiresVersion)) { plugin = null; return; }

			/*
			 * What does not matter for WriterSharp (heavy metadata)
			 * 
			 * AuthorName
			 * AuthorEmail
			 * OrganizationName
			 * OrganizationEmail
			 * PluginWebsite
			 * PluginRepository
			 * Description
			 * License
			 * ReadMe
			 * 
			 * That only matters for the WriterSharp package manager => W#-get
			 * The only exception to the "Don't say Writer#" rule
			 * 
			 */

			string pluginVersion = root.Attributes["PluginVersion"]?.Value ?? "untracked"; // defaults to untracked if none was specified

			// now, for the real deal
			var languages = root.GetElementsByTagName("Language"); // get languages
			HandlePluginLanguages(languages); // todo

			plugin = null; // todo

		}

	}

}

