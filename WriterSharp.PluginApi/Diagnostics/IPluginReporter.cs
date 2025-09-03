using System;


namespace WriterSharp.PluginApi.Diagnostics
{

	/// <summary>
	/// A state reporter for the plugin.
	/// </summary>
	public interface IPluginReporter
	{

		/// <summary>
		/// Reports an issue.
		/// </summary>
		/// <param name="issue">The description of the issue</param>
		/// <param name="severityLevel">The severity of the issue</param>
		void Report(string issue, SeverityLevel severityLevel = SeverityLevel.None);

		/// <summary>
		/// Reports a missing dependency.
		/// </summary>
		/// <param name="dependency">The missing dependency's name</param>
		/// <param name="severityLevel">The severity level of the issue</param>
		void ReportMissingDependency(string dependency, SeverityLevel severityLevel = SeverityLevel.High);

		/// <summary>
		/// Reports a performance issue.
		/// </summary>
		/// <param name="description">The description of the issue</param>
		/// <param name="expectedMs">An expected duration</param>
		/// <param name="actualMs">The actual duration</param>
		void ReportPerformanceIssue(string description, TimeSpan expectedMs, TimeSpan actualMs);

		/// <summary>
		/// Reports a critical vulnerability.
		/// </summary>
		/// <param name="description">The description opf the vulnerability</param>
		void ReportVulnerability(string description);

	}

}
