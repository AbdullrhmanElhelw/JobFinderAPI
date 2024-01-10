using FluentValidation;

namespace Application.Features.Commands.EmailCommands.ResetPassword;

public class ResetPasswordValidation : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .Equal(x => x.Password).WithMessage("Passwords do not match");

        RuleFor(x => x.OldPassword)
            .NotEmpty();

        RuleFor(x => x.Token)
            .NotEmpty();
    }
}