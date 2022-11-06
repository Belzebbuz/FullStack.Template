using App.Shared.Authentication;
using Infrastructure.Identity;
using Infrastructure.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data;

namespace Infrastructure.Context;

public class AppDbSeeder
{
	private readonly RoleManager<IdentityRole> _roleManager;
	private readonly UserManager<AppUser> _userManager;
	private readonly ILogger<AppDbSeeder> _logger;
	private readonly SecuritySettings _securitySettings;

	public AppDbSeeder(
		RoleManager<IdentityRole> roleManager, 
		UserManager<AppUser> userManager,
		ILogger<AppDbSeeder> logger,
		IOptions<SecuritySettings> securitySettings)
	{
		_roleManager = roleManager;
		_userManager = userManager;
		_logger = logger;
		_securitySettings = securitySettings.Value;
	}

	public async Task SeedDataAsync()
	{
		foreach (var role in SHRoles.DefaultRoles)
		{
			if(await _roleManager.Roles.SingleOrDefaultAsync(x => x.Name == role) == null)
			{
				await _roleManager.CreateAsync(new()
				{
					Name = role
				});
				_logger.LogInformation($"Role {role} created");
			}
		}

		if(await _userManager.Users.SingleOrDefaultAsync(x => x.Email == _securitySettings.RootUserEmail) == null)
		{
			var adminUser = AppUser.Create(_securitySettings.RootUserEmail, SHRoles.Admin, SHRoles.Admin, null, null);
			var passwordHash = new PasswordHasher<AppUser>().HashPassword(adminUser, _securitySettings.DefaultPassword);
			await _userManager.CreateAsync(adminUser);
			await _userManager.AddToRoleAsync(adminUser, SHRoles.Admin);
			_logger.LogInformation($"Root user {adminUser.Email} created");
		}
	}
}
