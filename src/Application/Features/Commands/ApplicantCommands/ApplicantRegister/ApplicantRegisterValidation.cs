using FluentValidation;

namespace Application.Features.Commands.ApplicantCommands.ApplicantRegister;

public class ApplicantRegisterValidation : AbstractValidator<ApplicantRegisterCommand>
{
    public ApplicantRegisterValidation()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is invalid.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
            .MaximumLength(50).WithMessage("Password must not exceed 50 characters.");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Confirm password is required.")
            .Equal(x => x.Password).WithMessage("Confirm password does not match.");

        RuleFor(x => x.Origin)
            .NotEmpty().WithMessage("Origin is required.")
            .Must(x => x.Contains("localhost") || x.Contains(""));
    }
}