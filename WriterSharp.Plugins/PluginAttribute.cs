using System;


namespace WriterSharp.Plugins
{

	/// <summary>
	/// Attribute that adds metadata to a plugin.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class PluginAttribute : Attribute
	{

		/// <summary>
		/// Plugin ID.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Plugin name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Plugin author.
		/// </summary>
		public string Author { get; set; }

		/// <summary>
		/// Plugin description.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Plugin version.
		/// </summary>
		public string Version { get; set; }

		/// <summary>
		/// Engine version required by the plugin.
		/// If null, any version is accepted.
		/// </summary>
		public string? RequiredVersion { get; set; }

		/// <summary>
		/// Plugin metadata attribute.
		/// </summary>
		/// <param name="id">Plugin ID.</param>
		/// <param name="name"></param>
		/// <param name="author"></param>
		/// <param name="description"></param>
		/// <param name="pluginVersion"></param>
		/// <param name="requiredEngineVersion"></param>
		public PluginAttribute(string id,
			string? name = null,
			string? author = null,
			string? description = null,
			string? pluginVersion = null,
			string? requiredEngineVersion = null)
		{

			Id = id;
			Name = name ?? id;
			Author = author ?? id;
			Description = description ?? "No description.";
			Version = pluginVersion ?? "1.0.0";
			RequiredVersion = requiredEngineVersion;

		}

	}

}
