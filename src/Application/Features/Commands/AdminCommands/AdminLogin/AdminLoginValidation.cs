using FluentValidation;

namespace Application.Features.Commands.AdminCommands.ApplicantLogin;

public class AdminLoginValidation : AbstractValidator<AdminLoginCommand>
{
    public AdminLoginValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}