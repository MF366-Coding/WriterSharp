using System;


namespace WriterSharp.Exceptions.IO
{

	/// <summary>
	/// A generic base exception that all WriterSharp exceptions related to IO inherit from.
	/// </summary>
	public class WriterSharpIOException : WriterSharpException
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="WriterSharpIOException" /> class.
		/// </summary>
		public WriterSharpIOException() : base() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="WriterSharpIOException" />
		/// with a custom error message.
		/// </summary>
		/// <param name="message">The custom error message</param>
		public WriterSharpIOException(string message) : base(message) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="WriterSharpIOException" />
		/// with a custom error message and a reference to the exception
		/// that caused this error.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="innerException"></param>
		public WriterSharpIOException(string? message, Exception? innerException) : base(message, innerException) { }

	}

}
