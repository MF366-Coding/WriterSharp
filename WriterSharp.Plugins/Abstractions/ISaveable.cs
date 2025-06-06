namespace WriterSharp.Plugins.Abstractions
{

	/// <summary>
	/// Blueprint for saveable items.
	/// Not used in files, but rather in saveable plugins.
	/// </summary>
	public interface ISaveable
	{

		/// <summary>
		/// Saves the current item.
		/// </summary>
		/// <returns>Information about the occurence.</returns>
		ReturnData? Save();

		/// <summary>
		/// Saves the current item.
		/// </summary>
		/// <param name="data">The data to add to what's being saved</param>
		/// <returns>Information about the occurence.</returns>
		ReturnData? Save(string? data);

	}

}
