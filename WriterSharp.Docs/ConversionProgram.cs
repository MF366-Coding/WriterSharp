namespace WriterSharp.Docs
{

	/// <summary>
	/// The conversion program to use.
	/// </summary>
	internal enum ConversionProgram
	{

		/// <summary>
		/// Default. Applies all default formatting. Supports PDF too.
		/// </summary>
		Emacs,

		/// <summary>
		/// Does not apply default formatting.
		/// </summary>
		Pandoc

	}

}
