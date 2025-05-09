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
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
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

		/// <summary>
		/// Creates a WriterSharp GUI translation.
		/// </summary>
		/// <param name="plugin">The name of the plugin that manages this translation</param>
		/// <param name="englishName">The English/universal name of the translation</param>
		/// <param name="realName">The "real" name of the translation, in the same language as the translation</param>
		/// <param name="translationFile">The translation file</param>
		/// <param name="englishTranslation"></param>
		public unsafe WriterSharpTranslation(string plugin, string englishName, string realName, string translationFile, in WriterSharpTranslation englishTranslation)
		{

			PluginName = plugin;
			TranslationNames = [englishName, realName];
			string fileContents;

			try
			{

				fileContents = File.ReadAllText(translationFile);

			}
			catch (FileNotFoundException)
			{

				Translation = null;
				return;

			}

			var rootNode = JsonNode.Parse(fileContents, new(), new() { CommentHandling = JsonCommentHandling.Skip }); // pretends comments ain't there, nice

			if (rootNode is not JsonObject jsonObject) { Translation = null; return; }
			KeyValuePair<string, string> kvp;

			Translation = [];

			foreach (var pair in jsonObject)
			{

				if (pair.Value is not JsonValue jsonValue) { Translation = null; return; }

				jsonValue.TryGetValue(out JsonElement jsonElement);

				if (jsonElement.ValueKind != JsonValueKind.String) { Translation = null; return; }
				kvp = KeyValuePair.Create(pair.Key, (jsonElement.GetString() ?? englishTranslation[pair.Key]) ?? pair.Key); // max safety: tries GetString, tries English, uses key

				Translation.Add(kvp.Key, kvp.Value);

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

		public Language(string plugin, string language, string grammarFile)
		{

			PluginName = plugin;
			LanguageName = language;
			// todo: work on dis !URGENT!

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

		private static byte HandlePluginLanguages(XmlNodeList languages, string pluginName, string innerName, ref Dictionary<string, Language> languageKVP)
		{

			var enumerator = languages.GetEnumerator();

			while (enumerator.MoveNext())
			{

				XmlNode language = (XmlNode)enumerator.Current;
				string? filetypes = language.Attributes?["Filetypes"]?.Value;
				string? filetype = language.Attributes?["Filetype"]?.Value;

				if (filetypes is null && filetype is null) return 1; // does not quality as a language

				// we don't care about the icon, it's irrelevant to us
				string name = (language.Attributes?["Name"]?.Value)
					?? ((filetypes ?? filetype)
						?? "UNKNOWN")
							.ToUpper();

				string filePath = Path.Join
				("Plugins", innerName, language.InnerText);

				if (!File.Exists(filePath)) return 2; // grammar doesn't exist

				if (filetypes is not null)
				{

					foreach (var allowedFiletype in filetypes.Split(';'))
					{

						languageKVP.Add($".{allowedFiletype}", new(pluginName, name, Path.GetFullPath(filePath)));

					}

				}
				else
				{

					Debug.Assert(filetype is not null, "Unexpected null filetype."); // this will NEVER EVER run, but it pleases .NET sooo
					languageKVP.Add($".{filetype}", new(pluginName, name, Path.GetFullPath(filePath)));

				}

			}

			return 0;

		}

		public unsafe static void InterpretPluginXML(XmlDocument xmlDocument, ref Dictionary<string, Language> languageKVP, out WriterSharpPlugin? plugin)
		{

			var root = xmlDocument.DocumentElement;
			if (root is null) { plugin = null; return; }

			string? pluginInnerName = root.Attributes["InnerName"]?.Value;
			if (pluginInnerName is null) { plugin = null; return; }

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
			HandlePluginLanguages(languages, pluginName, pluginInnerName, ref languageKVP);

			plugin = null; // todo: add the rest

		}

	}

}

