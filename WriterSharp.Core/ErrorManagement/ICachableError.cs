using System;


namespace WriterSharp.Core.ErrorManagement
{

	/// <summary>
	/// Blueprint for a cachable error.
	/// </summary>
	public interface ICachableError
	{

		/// <summary>
		/// The error code.
		/// </summary>
		public int ErrorCode { get; init; }

		/// <summary>
		/// The error message.
		/// </summary>
		public string Message { get; init; }

		/// <summary>
		/// The exception that caused this error.
		/// </summary>
		public Exception? Exception { get; init; } 

	}

}
