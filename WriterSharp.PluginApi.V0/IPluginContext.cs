using WriterSharp.PluginApi.V0.Language;
using WriterSharp.PluginApi.V0.Theming;
using WriterSharp.PluginApi.V0.Utils;


namespace WriterSharp.PluginApi.V0
{

	/// <summary>
	/// Blueprint for plugin contexts.
	/// </summary>
	public interface IPluginContext
	{

		/// <summary>
		/// The global logger for WriterSharp.
		/// </summary>
		ILogger Log { get; set; }

		/// <summary>
		/// The file service for WriterSharp.
		/// </summary>
		IFileService Files { get; set; }

		/// <summary>
		/// The global WriterSharp language manager.
		/// </summary>
		ILanguageManager Languages { get; set; }

		/// <summary>
		/// The global WriterSharp theme and flavor manager.
		/// </summary>
		IThemingManager Themes { get; set; }

	}

}
