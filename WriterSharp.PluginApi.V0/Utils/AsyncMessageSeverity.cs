namespace WriterSharp.PluginApi.V0.Utils
{

	/// <summary>
	/// The severity of the async message.
	/// </summary>
	public enum AsyncMessageSeverity : byte
	{

		/// <summary>
		/// A neutral message.
		/// </summary>
		NeutralMessage,

		/// <summary>
		/// An info message.
		/// </summary>
		Info,

		/// <summary>
		/// A success message.
		/// </summary>
		Success,

		/// <summary>
		/// A warning message.
		/// </summary>
		Warning,

		/// <summary>
		/// An error message.
		/// </summary>
		Error

	}

}
