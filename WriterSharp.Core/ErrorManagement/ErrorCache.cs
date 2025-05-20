using System;
using System.Collections.Generic;
using System.Linq;


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
		/// Rethrows the last exception of the list of cached exceptions.
		/// Does not throw anything if there aren't any cached exceptions.
		/// </summary>
		public static void RethrowMostRecentException()
		{

			if (!HasCachedErrors()) return;
			var lastError = errors.Last();

			var exception = (lastError.Exception) ?? new Exception($"Rethrowing error - ICachableError({lastError.ErrorCode}, {lastError.Message})");

			throw exception;

		}

		/// <summary>
		/// Rethrows the last exception of the list of cached exceptions.
		/// </summary>
		/// <param name="alwaysThrow">When set to true, will throw an exception even if there are no cahced errors to rethrow</param>
		/// <exception cref="Exception">Thrown when there are no cached errors (requires alwaysThrow to be true)</exception>
		public static void RethrowMostRecentException(bool alwaysThrow)
		{

			if (!HasCachedErrors() && alwaysThrow)
			{

				throw new Exception("No cached errors to rethrow.");

			}

			else
			{

				RethrowMostRecentException();

			}

		}

		/// <summary>
		/// Rethrows the last exception of the list of cached exceptions.
		/// </summary>
		/// <param name="toThrowIfNone">Exception to throw when there are no cached errors to rethrow</param>
		public static void RethrowMostRecentException(Exception toThrowIfNone)
		{

			if (!HasCachedErrors())
			{

				throw toThrowIfNone;

			}

			else
			{

				RethrowMostRecentException();

			}

		}

		/// <summary>
		/// Clears the error cache.
		/// </summary>
		public static void Clear()
		{

			errors.Clear();

		}

	}

}
