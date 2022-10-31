using App.Shared.Wrapper;
using Domain.Base;

namespace Application.Contracts.Repository;

public interface IRepository<T> where T : class, IAggregateRoot
{
	public Task<T> SingleAsync(Func<T, bool> predicate);
	public Task<ICollection<T>> GetAsync(Func<T, bool> predicate);
	public Task<IResult> AddAsync(T entity);
	public Task<IResult> UpdateAsync(T entity);
	public Task<IResult> DeleteAsync(T entity);
}

public interface IReadRepository<T> where T : class, IAggregateRoot
{
	public Task<T> SingleAsync(Func<T, bool> predicate);
	public Task<ICollection<T>> GetAsync(Func<T, bool> predicate);
}