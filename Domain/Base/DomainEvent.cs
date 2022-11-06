using App.Shared;

namespace Domain.Base;

public abstract class DomainEvent : IEvent
{
	public DateTime TriggeredOn { get; protected set; } = DateTime.UtcNow;
}