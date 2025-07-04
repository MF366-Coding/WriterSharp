namespace WriterSharp.PluginApi
{

	/// <summary>
	/// Represents a plugin to extend WriterSharp's functionalities.
	/// </summary>
	public interface IWriterSharpPlugin
	{

		/// <summary>
		/// A unique ID for the plugin.
		/// One may use a GUID if their ID would be otherwise too common.
		/// </summary>
		string Id { get; init; }

		/// <summary>
		/// The name of the plugin.
		/// </summary>
		string Name { get; init; }

		/// <summary>
		/// A brief description of the plugin.
		/// </summary>
		string Description { get; init; }

		/// <summary>
		/// The author of the plugin.
		/// </summary>
		string Author { get; init; }

		/// <summary>
		/// The current version of the plugin.
		/// </summary>
		string Version { get; init; }

		/// <summary>
		/// Initializes a plugin, given a context.
		/// </summary>
		/// <param name="context">The plugin context</param>
		void Initialize(IPluginContext context);

		/// <summary>
		/// Method called on shutdown.
		/// </summary>
		void Shutdown();

	}

}
