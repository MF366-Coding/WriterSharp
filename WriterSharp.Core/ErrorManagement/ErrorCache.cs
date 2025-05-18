using System.Collections.Generic;


namespace WriterSharp.Core.ErrorManagement
{

	/// <summary>
	/// WriterSharp's centralized place for error caching.
	/// </summary>
	public class ErrorCache
	{

		/// <summary>
		/// The list of cached errors.
		/// </summary>
		private static readonly List<ICachableError> errors = new();

		/// <summary>
		/// Registers the occurence of a brand new error.
		/// </summary>
		/// <param name="error">The error that occured</param>
		public static void RegisterError(ICachableError error)
		{

			errors.Add(error);

		}

		/// <summary>
		/// Returns the currently cached errors.
		/// </summary>
		/// <returns>Cached errors, in a readonly list</returns>
		public static IReadOnlyList<ICachableError> GetErrors() => errors.AsReadOnly();

		/// <summary>
		/// Checks if there are any cached errors.
		/// </summary>
		/// <returns></returns>
		public static bool HasCachedErrors() => errors.Count > 0;

		/// <summary>
		/// Clears the error cache.
		/// </summary>
		public static void Clear()
		{

			errors.Clear();

		}

	}

}
