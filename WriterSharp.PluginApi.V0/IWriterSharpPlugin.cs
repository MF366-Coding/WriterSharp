namespace WriterSharp.PluginApi.V0
{
	
	/// <summary>
	/// Blueprint for a plugin.
	/// </summary>
	public interface IWriterSharpPlugin
	{

		/// <summary>
		/// The name of the plugin.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// The version of the plugin.
		/// </summary>
		string Version { get; }
		
		/// <summary>
		/// The author of the plugin.
		/// </summary>
		string Author { get; }

		/// <summary>
		/// Initializes the current plugin.
		/// </summary>
		/// <param name="context">The context to give this plugin.</param>
		void Initialize(IPluginContext context);

		/// <summary>
		/// Safely shuts down a plugin.
		/// </summary>
		void Shutdown();

	}

}
