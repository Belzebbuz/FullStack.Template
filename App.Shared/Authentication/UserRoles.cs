using System.Collections.ObjectModel;

namespace App.Shared.Authentication;

public class UserRoles
{
	public const string Admin = nameof(Admin);
	public const string Basic = nameof(Basic);
	public static IReadOnlyList<string> DefaultRoles { get; } = new ReadOnlyCollection<string>(new[]
	{
		Admin,
		Basic
	});
}
