using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Startup
{
	public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
	{
		return services;
	}
}
