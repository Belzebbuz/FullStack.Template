using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Context;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
	private readonly DatabaseSettings _dbSettings;

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
		IOptions<DatabaseSettings> dbSettings)
		: base(options)
	{
		_dbSettings = dbSettings.Value;
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
	}
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseDatabase(_dbSettings.Provider!, _dbSettings.ConnectionString!);
	}
}
