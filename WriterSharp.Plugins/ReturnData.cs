using System;


namespace WriterSharp.Plugins
{

	/// <summary>
	/// Return data for a plugin interaction.
	/// </summary>
	/// <param name="Id">A unique ID for this response.</param>
	/// <param name="IsSuccessful">Whether the action was successful (true) or not (false).</param>
	/// <param name="Code">The return code, as a <see cref="UInt16" />.</param>
	/// <param name="Message">The return message. May be null.</param>
	/// <param name="VerboseValue">
	/// The verbose value. This is the parameter you'd want to use for cases where
	/// you want to also return some sort of value and it can be stringified.
	/// May be null.
	/// </param>
	/// <param name="AdditionalInformation">
	/// Additional information in the form of a string.
	/// May be null.
	/// </param>
	/// <param name="InnerException">
	/// In case this action faulted, the exception that caused it to error out.
	/// Set to null if the action was sucessful.
	/// </param>
	public record ReturnData(
		int Id,
		bool IsSuccessful,
		ushort Code,
		string? Message,
		string? VerboseValue = null,
		string? AdditionalInformation = null,
		Exception? InnerException = null
	);

	/// <summary>
	/// Return data for a plugin interaction.
	/// </summary>
	/// <typeparam name="TValue">The type of <paramref name="VerboseValue"/>.</typeparam>
	/// <param name="Id">A unique ID for this response.</param>
	/// <param name="IsSuccessful">Whether the action was successful (true) or not (false).</param>
	/// <param name="Code">The return code, as a <see cref="UInt16" />.</param>
	/// <param name="Message">The return message. May be null.</param>
	/// <param name="VerboseValue">
	/// The verbose value. This is the parameter you'd want to use for cases where
	/// you want to also return some sort of value of type <typeparamref name="TValue"/>.
	/// May be null.
	/// </param>
	/// <param name="AdditionalInformation">
	/// Additional information in the form of a string.
	/// May be null.
	/// </param>
	/// <param name="InnerException">
	/// In case this action faulted, the exception that caused it to error out.
	/// Set to null if the action was sucessful.
	/// </param>
	public record ReturnData<TValue>(
		int Id,
		bool IsSuccessful,
		ushort Code,
		string? Message,
		TValue? VerboseValue = null,
		string? AdditionalInformation = null,
		Exception? InnerException = null
	)
		where TValue : class;

}
