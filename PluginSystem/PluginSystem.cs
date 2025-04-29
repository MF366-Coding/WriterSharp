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
using System.Xml;


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

}

