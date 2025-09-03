using WriterSharp.PluginApi.Diagnostics;
using WriterSharp.PluginApi.IO;
using WriterSharp.PluginApi.Settings;
using WriterSharp.PluginApi.Sharing;


namespace WriterSharp.PluginApi
{

	/// <summary>
	/// The plugin context.
	/// </summary>
	public interface IPluginContext
	{

		/// <summary>
		/// Manages commands that the user can call.
		/// </summary>
		ICommandManager Commands { get; }

		/// <summary>
		/// Dependency container for WriterSharp.
		/// </summary>
		IDependencyContainer Dependencies { get; }

		/// <summary>
		/// Manages events related to WriterSharp.
		/// </summary>
		IEventManager Events { get; }

		/// <summary>
		/// The sharded, recommended way for plugins to access
		/// files from disk.
		/// </summary>
		IFileSystem FileSystem { get; }

		/// <summary>
		/// Manages keyboard gestures loaded into WriterSharp.
		/// </summary>
		IGestureManager Gestures { get; }

		/// <summary>
		/// Reporter for issues, such as performance issues.
		/// </summary>
		IPluginReporter IssueReporter { get; }

		/// <summary>
		/// Manages languages loaded into WriterSharp.
		/// </summary>
		ILanguageManager Languages { get; }

		/// <summary>
		/// The WriterSharp logger.
		/// </summary>
		ILogger Logger { get; }

		/// <summary>
		/// The WriterSharp resource manager, for communication between plugins.
		/// </summary>
		IResourceManager Resources { get; }

		/// <summary>
		/// Manages plugin's settings via WriterSharp (for security).
		/// </summary>
		ISettingsManager Settings { get; }

		/// <summary>
		/// Manages theming functionality loaded into
		/// WriterSharp.
		/// </summary>
		IThemingManager Themes { get; }

		/// <summary>
		/// Disables the plugin.
		/// </summary>
		void Disable();

	}

}
