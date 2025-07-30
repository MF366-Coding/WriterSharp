using WriterSharp.PluginApi.FileSystem;
using WriterSharp.PluginApi.Settings;


namespace WriterSharp.PluginApi
{

	/// <summary>
	/// The plugin context.
	/// </summary>
	public interface IPluginContext
	{

		/// <summary>
		/// The sharded, recommended way for plugins to access
		/// files from disk.
		/// </summary>
		IFileSystem FileSystem { get; }

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
		/// Manages commands that the user can call.
		/// </summary>
		ICommandManager Commands { get; }

		/// <summary>
		/// Manages plugin's settings via WriterSharp (for security).
		/// </summary>
		ISettingsManager Settings { get; }

	}

}
