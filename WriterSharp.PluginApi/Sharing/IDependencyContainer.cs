namespace WriterSharp.PluginApi.Sharing
{

	/// <summary>
	/// Dependency container for WriterSharp plugins.
	/// </summary>
	public interface IDependencyContainer
	{

		/// <summary>
		/// Gets a service, if such is both registered and available.
		/// </summary>
		/// <typeparam name="TService"></typeparam>
		/// <returns></returns>
		TService Get<TService>();

		/// <summary>
		/// Injects a service.
		/// </summary>
		/// <typeparam name="TService">The type of the service</typeparam>
		void Inject<TService>();

		/// <summary>
		/// Checks if a service is available.
		/// </summary>
		/// <typeparam name="TService">The type of the service</typeparam>
		/// <returns><c>true</c> if available</returns>
		bool IsAvailable<TService>();

		/// <summary>
		/// Checks if a service is registered.
		/// </summary>
		/// <typeparam name="TService">The type of the service</typeparam>
		/// <returns><c>true</c> if registered</returns>
		bool IsRegistered<TService>();

	}

}
