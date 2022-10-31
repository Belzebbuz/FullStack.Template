using App.Shared.Wrapper;
using Application.Contracts.Repository;
using Domain.Base;

namespace Infrastructure.Context;

public class Repository<T> : IRepository<T> 
	where T : class, IAggregateRoot
{
	public Task<IResult> AddAsync(T entity)
	{
		throw new NotImplementedException();
	}

	public Task<IResult> DeleteAsync(T entity)
	{
		throw new NotImplementedException();
	}

	public Task<ICollection<T>> GetAsync(Func<T, bool> predicate)
	{
		throw new NotImplementedException();
	}

	public Task<T> SingleAsync(Func<T, bool> predicate)
	{
		throw new NotImplementedException();
	}

	public Task<IResult> UpdateAsync(T entity)
	{
		throw new NotImplementedException();
	}
}
