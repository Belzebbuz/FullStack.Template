﻿using System.Security.Claims;

namespace Infrastructure.Security;

public class CurrentUser : ICurrentUser, ICurrentUserInitializer
{
	private ClaimsPrincipal? _user;

	public string? Name => _user?.Identity?.Name;

	private Guid _userId = Guid.Empty;
	public Guid GetUserId() =>
		IsAuthenticated()
			? Guid.Parse(_user?.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString())
			: _userId;

	public string? GetUserEmail() =>
		IsAuthenticated()
			? _user!.FindFirstValue(ClaimTypes.Email)
			: string.Empty;

	public bool IsAuthenticated() =>
		_user?.Identity?.IsAuthenticated is true;

	public bool IsInRole(string role) =>
		_user?.IsInRole(role) is true;

	public IEnumerable<Claim>? GetUserClaims() =>
		_user?.Claims;

	public void SetCurrentUser(ClaimsPrincipal user)
	{
		if (_user != null)
		{
			throw new Exception("Method reserved for in-scope initialization");
		}

		_user = user;
	}

	public void SetCurrentUserId(string userId)
	{
		if (_userId != Guid.Empty)
		{
			throw new Exception("Method reserved for in-scope initialization");
		}

		if (!string.IsNullOrEmpty(userId))
		{
			_userId = Guid.Parse(userId);
		}
	}
}

public interface ICurrentUser
{
	string? Name { get; }

	Guid GetUserId();

	string? GetUserEmail();

	bool IsAuthenticated();

	bool IsInRole(string role);

	IEnumerable<Claim>? GetUserClaims();
}

public interface ICurrentUserInitializer
{
	void SetCurrentUser(ClaimsPrincipal user);

	void SetCurrentUserId(string userId);
}