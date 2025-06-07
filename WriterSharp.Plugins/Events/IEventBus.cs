using System;


namespace WriterSharp.Plugins.Events
{

	/// <summary>
	/// Blueprint for event buses.
	/// </summary>
	public interface IEventBus
	{

		/// <summary>
		/// Subscribes to an event.
		/// </summary>
		/// <typeparam name="TEvent">The event to subscribe to</typeparam>
		/// <returns>Information about the subscription to the event</returns>
		ReturnData<TEvent> Subscribe<TEvent>(Action<TEvent> handler)
			where TEvent : class, IEvent, new();

		/// <summary>
		/// Unsubscribes from an event.
		/// </summary>
		/// <typeparam name="TEvent">The event to unsubscribe from</typeparam>
		/// <returns>Information about the subscription to the event</returns>
		ReturnData<TEvent> Unsubscribe<TEvent>(Action<TEvent> handler)
			where TEvent : class, IEvent, new();

		/// <summary>
		/// Describes an event in English.
		/// </summary>
		/// <typeparam name="TEvent">The event to describe</typeparam>
		/// <returns>A string, containing a description of the event</returns>
		string DescribeEvent<TEvent>()
			where TEvent : class, IEvent, new();

	}

}
