namespace WriterSharp.PluginApi.Diagnostics
{

	/// <summary>
	/// The severity level of a diagnosis/issue.
	/// </summary>
	public enum SeverityLevel
	{

		/// <summary>
		/// No severity at all.
		/// </summary>
		None,

		/// <summary>
		/// Information severity.
		/// </summary>
		Low,

		/// <summary>
		/// Warning severity.
		/// </summary>
		Medium,

		/// <summary>
		/// Error severity (non-critical).
		/// </summary>
		High,

		/// <summary>
		/// Error severity (critical).
		/// </summary>
		Critical

	}

}
