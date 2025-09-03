namespace WriterSharp.PluginApi.Sharing
{

	/// <summary>
	/// A WriterSharp service.
	/// </summary>
	public interface IService
	{

		/// <summary>
		/// Whether the service is available for public usage.
		/// </summary>
		bool IsAvailable { get; set; }

	}

}
