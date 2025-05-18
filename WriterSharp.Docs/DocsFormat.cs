namespace WriterSharp.Docs
{

	/// <summary>
	/// The documentation format to convert to.
	/// </summary>
	internal enum DocsFormat
	{

		/// <summary>
		/// Converts Org Mode to HTML.
		/// </summary>
		HTML,

		/// <summary>
		/// Converts Org Mode to Markdown.
		/// </summary>
		Markdown,

		/// <summary>
		/// Converts Org Mode to PDF. Requires a LaTeX engine.
		/// </summary>
		PDFLatex

	}

}
