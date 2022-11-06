
using App.Shared;
using Application.Contracts.DI;

namespace Application.Contracts.Services.Events;

public interface IEventPublisher : ITransientService
{
	Task PublishAsync(IEvent @event);
}