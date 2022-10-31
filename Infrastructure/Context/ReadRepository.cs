using Application.Contracts.Repository;
using Domain.Base;

namespace Infrastructure.Context;

public class ReadRepository<T> : IReadRepository<T>
	where T : class, IAggregateRoot
{
	public Task<ICollection<T>> GetAsync(Func<T, bool> predicate)
	{
		throw new NotImplementedException();
	}

	public Task<T> SingleAsync(Func<T, bool> predicate)
	{
		throw new NotImplementedException();
	}
}
