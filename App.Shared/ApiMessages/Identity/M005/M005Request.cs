namespace App.Shared.ApiMessages.Identity.M005;
/// <summary>
/// User registraion request
/// </summary>
public class M005Request
{
	public string FirstName { get; set; } = default!;
	public string LastName { get; set; } = default!;
	public string Email { get; set; } = default!;
	public string UserName { get; set; } = default!;
	public string Password { get; set; } = default!;
	public string? PhoneNumber { get; set; }
}
