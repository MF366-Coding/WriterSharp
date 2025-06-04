namespace WriterSharp.Abstractions.Logger
{

	/// <summary>
	/// Enumerates different levels of log severity.
	/// </summary>
	public enum LogSeverity
	{

		/// <summary>
		/// Neutral severity.
		/// </summary>
		Neutral,

		/// <summary>
		/// Info severity.
		/// Associated with the color blue and the <strong>[INFO]</strong>
		/// designation.
		/// </summary>
		Info,

		/// <summary>
		/// Success severity.
		/// Associated with the color green and the <strong>[SUCCESS]</strong>
		/// designation.
		/// </summary>
		Success,

		/// <summary>
		/// Warning severity.
		/// Associated with the color yellow and the <strong>[WARNING]</strong>
		/// or the <strong>[!]</strong> designations.
		/// </summary>
		Warning,

		/// <summary>
		/// Error severity.
		/// Associated with the color red and the <strong>[ERROR]</strong>
		/// or the <strong>[!!]</strong> designations.
		/// </summary>
		Error,

		/// <summary>
		/// Warning severity.
		/// Associated with the color red and the <strong>[CRITICAL]</strong>
		/// or the <strong>[!!!]</strong> designations.
		/// </summary>
		Critical

	}

}
