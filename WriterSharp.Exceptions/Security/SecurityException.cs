using System;


namespace WriterSharp.Exceptions.Security
{

	/// <summary>
	/// Exceptions that is thrown when an authorized caller attempts to run a WriterSharp command.
	/// </summary>
	public class SecurityException : WriterSharpException
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="SecurityException" /> class.
		/// </summary>
		public SecurityException() : base() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="SecurityException" />
		/// with a custom error message.
		/// </summary>
		/// <param name="message">The custom error message</param>
		public SecurityException(string message) : base(message) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="SecurityException" />
		/// with a custom error message and a reference to the exception
		/// that caused this error.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="innerException"></param>
		public SecurityException(string? message, Exception? innerException) : base(message, innerException) { }

	}

}
