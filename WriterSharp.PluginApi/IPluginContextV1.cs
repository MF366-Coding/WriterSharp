namespace WriterSharp.PluginApi
{

	public interface IPluginContextV1
	{

		/// <summary>
		/// Manages languages loaded into WriterSharp.
		/// </summary>
		ILanguageManager Languages { get; }

		/// <summary>
		/// Manages theming functionality loaded into
		/// WriterSharp.
		/// </summary>
		IThemingManager Themes { get; }

		/// <summary>
		/// Manages events related to WriterSharp.
		/// </summary>
		IEventManager Events { get; }

		/// <summary>
		/// Manages keyboard gestures loaded into WriterSharp.
		/// </summary>
		IGestureManager Gestures { get; }

		/// <summary>
		/// Manages plugin's settings via WriterSharp (for security).
		/// </summary>
		ISettingsManager Settings { get; }

	}

}
