using App.Shared.Wrapper;
using Ardalis.Specification;
using Domain.Base;
using System.Linq.Expressions;

namespace Application.Contracts.Repository;

public interface IRepository<T> : IRepositoryBase<T>
	where T : class, IAggregateRoot
{

}

public interface IReadRepository<T> : IReadRepositoryBase<T>
	where T : class, IAggregateRoot
{

}