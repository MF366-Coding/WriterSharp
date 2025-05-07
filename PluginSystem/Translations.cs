/*
 *  _____                            _          _     _                   
 * |_   _|  _ _   __ _   _ _    ___ | |  __ _  | |_  (_)  ___   _ _    ___
 *   | |   | '_| / _` | | ' \  (_-< | | / _` | |  _| | | / _ \ | ' \  (_-<
 *   |_|   |_|   \__,_| |_||_| /__/ |_| \__,_|  \__| |_| \___/ |_||_| /__/
 *                                                                        
 */


// System
using System;

// Avalonia
using Avalonia;
using Avalonia.Controls;


namespace WriterSharp.Translations
{

	public static class TranslationProperties
	{

		/// <summary>
		/// Translatable property.
		/// </summary>
		public static readonly AttachedProperty<bool> translatable
			= AvaloniaProperty.RegisterAttached<Control, bool>("Translatable", typeof(TranslationProperties), true);

		/// <summary>
		/// TranslationKey property.
		/// </summary>
		public static readonly AttachedProperty<string> translationKey
			= AvaloniaProperty.RegisterAttached<Control, string>("TranslationKey", typeof(TranslationProperties));

		/// <summary>
		/// Set an element as translatable.
		/// </summary>
		/// <param name="value">True if translatable</param>
		public static IDisposable? SetTranslatable(AvaloniaObject element, bool value) => element.SetValue(translatable, value);

		/// <summary>
		/// Set an element's translation key.
		/// </summary>
		/// <param name="value">Translation key</param>
		/// <exception cref="NotSupportedException">Element is not translatable</exception>
		public static IDisposable? SetTranslationKey(AvaloniaObject element, string value)
		{

			if (element.GetValue(translatable) == false) throw new NotSupportedException("Translations are disabled for this element");
			return element.SetValue(translationKey, value);

		}

		/// <summary>
		/// Check if an element is translatable.
		/// </summary>
		public static bool GetTranslatable(AvaloniaObject element) => element.GetValue(translatable);

		/// <summary>
		/// Check an element's translation key.
		/// </summary>
		public static string GetTranslationKey(AvaloniaObject element) => element.GetValue(translationKey);

	}

}

