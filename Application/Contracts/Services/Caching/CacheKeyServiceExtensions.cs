﻿using Domain.Base;

namespace Application.Contracts.Services.Caching;

public static class CacheKeyServiceExtensions
{
	public static string GetCacheKey<TEntity>(this ICacheKeyService cacheKeyService, object id)
		where TEntity : IEntity =>
		cacheKeyService.GetCacheKey(typeof(TEntity).Name, id);
}