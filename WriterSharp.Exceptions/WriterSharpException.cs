using System;


namespace WriterSharp.Exceptions
{

	/// <summary>
	/// A generic base exception that all WriterSharp exceptions inherit from.
	/// </summary>
	public class WriterSharpException : Exception
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="WriterSharpException" /> class.
		/// </summary>
		public WriterSharpException() : base() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="WriterSharpException" />
		/// with a custom error message.
		/// </summary>
		/// <param name="message">The custom error message</param>
		public WriterSharpException(string message) : base(message) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="WriterSharpException" />
		/// with a custom error message and a reference to the exception
		/// that caused this error.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="innerException"></param>
		public WriterSharpException(string? message, Exception? innerException) : base(message, innerException) { }

	}

}
