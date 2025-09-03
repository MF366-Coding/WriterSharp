namespace WriterSharp.PluginApi.Sharing
{

	/// <summary>
	/// A read-only resource.
	/// </summary>
	public interface IReadOnlyResource<out TObject>
	{

		/// <summary>
		/// Gets the object as readonly.
		/// </summary>
		/// <returns>The readonly object</returns>
		TObject? AsReadOnly();

		/// <summary>
		/// Frees the memory used by this object.
		/// </summary>
		void Free();

		/// <summary>
		/// Gets a mutable copy of the object that's entirely detached.
		/// </summary>
		/// <returns>The copy of the object</returns>
		TObject? GetDetachedCopy();

	}

}
