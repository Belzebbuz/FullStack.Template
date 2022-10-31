﻿using App.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Base;

public abstract class BaseEntity : BaseEntity<Guid>
{
}

public abstract class BaseEntity<TId> : IEntity<TId>
{
	public TId Id { get; protected set; } = default!;

	[NotMapped]
	public List<DomainEvent> DomainEvents { get; } = new();
}

public interface IEntity<TId> : IEntity
{
	TId Id { get; }
}

public interface IEntity
{
	List<DomainEvent> DomainEvents { get; }
}

public abstract class DomainEvent : IEvent
{
	public DateTime TriggeredOn { get; protected set; } = DateTime.UtcNow;
}