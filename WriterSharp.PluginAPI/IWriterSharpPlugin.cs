namespace WriterSharp.PluginAPI
{

	public interface IWriterSharpPlugin
	{

		/// <summary>
		/// Initializes the plugin.
		/// </summary>
		/// <param name="pluginAPI">The plugin API to use</param>
		void Initialize(IPluginAPI pluginAPI);

		/// <summary>
		/// Called on safe app shutdown.
		/// </summary>
		void Dispose();

		/// <summary>
		/// The plugin's metadata.
		/// </summary>
		PluginMetadata Metadata { get; set; }

	}

}
