using FluentValidation;

namespace Application.Features.Commands.CompanyCommands.CompanyLogin;

public class CompanyLoginValidation : AbstractValidator<CompanyLoginCommand>
{
    public CompanyLoginValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters");
    }
}
