using Domain.Base;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class AppUser : IdentityUser, IAggregateRoot
{
	public string FirstName { get; set; }
	public string? LastName { get; set; }
	public bool IsActive { get; set; }
	public static AppUser Create(string userName, string eMail, string firstName, string lastName = null)
	{
		if(userName == null) throw new ArgumentNullException(nameof(userName));
		if(eMail == null) throw new ArgumentNullException(nameof(eMail));
		if(firstName == null) throw new ArgumentNullException(nameof(firstName));
		return new()
		{
			UserName = userName,
			Email = eMail,
			FirstName = firstName,
			LastName = lastName,
			IsActive = true
		};
	}
}
