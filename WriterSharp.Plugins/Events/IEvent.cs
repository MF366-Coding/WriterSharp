namespace WriterSharp.Plugins.Events
{

	/// <summary>
	/// Blueprint for events.
	/// </summary>
	public interface IEvent
	{

		/// <summary>
		/// The name of this event.
		/// </summary>
		string FriendlyName { get; init; }

		/// <summary>
		/// The English description of this event.
		/// </summary>
		string? Description { get; init; }

	}

}
