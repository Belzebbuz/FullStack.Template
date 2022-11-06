using FluentValidation;

namespace App.Shared.ApiMessages.Identity.M001;

/// <summary>
/// Token request message
/// </summary>
/// <param name="Email"></param>
/// <param name="Password"></param>
public record M001Request(string Email, string Password);

public class M001RequestValidator : AbstractValidator<M001Request>
{
	public M001RequestValidator()
	{
		RuleFor(p => p.Email).Cascade(CascadeMode.Stop)
			.NotEmpty()
			.EmailAddress()
			.WithMessage("Invalid Email Address.");

		RuleFor(p => p.Password).Cascade(CascadeMode.Stop)
			.NotEmpty();
	}
}

