using System.Threading.Tasks;


namespace WriterSharp.PluginApi.Resources
{

	/// <summary>
	/// A resource manager for sharability purposes.
	/// </summary>
	public interface IResourceManager
	{

		/// <summary>
		/// Creates a sharable readonly resource.
		/// </summary>
		/// <param name="params">The parameters of the resource</param>
		/// <typeparam name="T">The type of the resource</typeparam>
		/// <returns>The resource</returns>
		Task<IReadOnlyResource<T>> CreateSharableResource<T>(params object?[]? @params);

		/// <summary>
		/// Gets a shared readonly resource.
		/// </summary>
		/// <param name="id">The ID of the resource</param>
		/// <typeparam name="T">The type of the resource</typeparam>
		/// <returns>The resource</returns>
		Task<IReadOnlyResource<T>> Get<T>(string? id);

		/// <summary>
		/// Shares a readonly resource with all the plugins.
		/// </summary>
		/// <param name="id">The ID of the resource</param>
		/// <param name="obj">The object to share</param>
		/// <typeparam name="T">The type of the resource</typeparam>
		Task Share<T>(string? id, IReadOnlyResource<T> obj);

	}

}
