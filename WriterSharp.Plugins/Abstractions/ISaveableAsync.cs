using System.Threading.Tasks;


namespace WriterSharp.Plugins.Abstractions
{

	/// <summary>
	/// Blueprint for saveable items, asynchronously.
	/// Not used in files, but rather in saveable plugins.
	/// </summary>
	public interface ISaveableAsync
	{

		/// <summary>
		/// Saves the current item.
		/// </summary>
		/// <returns>Information about the occurence.</returns>
		Task<ReturnData?> SaveAsync();

		/// <summary>
		/// Saves the current item.
		/// </summary>
		/// <param name="data">The data to add to what's being saved</param>
		/// <returns>Information about the occurence.</returns>
		Task<ReturnData?> SaveAsync(string? data);

	}

}
