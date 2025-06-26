namespace WriterSharp.PluginApi.V0.Theming
{

	/// <summary>
	/// Properties for the formatting of a token.
	/// </summary>
	public struct TextFormatting
	{

		/// <summary>
		/// The background color of the token.
		/// </summary>
		public string? BackgroundColor { get; set; }

		/// <summary>
		/// The foreground color of the token.
		/// </summary>
		public string TextColor { get; set; }

		/// <summary>
		/// Whether the token should be <strong>bold</strong>.
		/// </summary>
		public bool Bold { get; set; }

		/// <summary>
		/// Whether the token should be <i>italic</i>.
		/// </summary>
		public bool Italic { get; set; }

		/// <summary>
		/// Whether the token should be <s>strikethrough</s>.
		/// </summary>
		public bool Strikethrough { get; set; }

		/// <summary>
		/// Whether the token should be <u>underline</u>.
		/// </summary>
		public bool Underline { get; set; }

	}

}
