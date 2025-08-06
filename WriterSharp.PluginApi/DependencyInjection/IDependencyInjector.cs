using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;


namespace WriterSharp.PluginApi.DependencyInjection
{

	/// <summary>
	/// Dependency injector for WriterSharp plugins.
	/// </summary>
	public interface IDependencyInjector
	{

		/// <summary>
		/// Injects a plugin into WriterSharp.
		/// </summary>
		/// <param name="assembly">The assembly in which the plugin is located</param>
		/// <returns><c>true</c> if successful</returns>
		Task<bool> InjectPluginAsync(Assembly assembly);

		/// <summary>
		/// Injects a plugin into WriterSharp.
		/// </summary>
		/// <param name="assembly">The assembly in which the plugin is located</param>
		/// <param name="cancellationToken">The cancellation token to use</param>
		/// <returns><c>true</c> if successful</returns>
		Task<bool> InjectPluginAsync(Assembly assembly, CancellationToken cancellationToken);

		/// <summary>
		/// Injects a plugin into WriterSharp.
		/// </summary>
		/// <param name="type">The class of the plugin</param>
		/// <returns><c>true</c> if successful</returns>
		Task<bool> InjectPluginAsync(Type type);

		/// <summary>
		/// Injects a plugin into WriterSharp.
		/// </summary>
		/// <param name="type">The class of the plugin</param>
		/// <param name="cancellationToken">The cancellation token to use</param>
		/// <returns><c>true</c> if successful</returns>
		Task<bool> InjectPluginAsync(Type type, CancellationToken cancellationToken);

	}

}
