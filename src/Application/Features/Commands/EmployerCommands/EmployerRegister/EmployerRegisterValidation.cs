using FluentValidation;

namespace Application.Features.Commands.EmployerCommands.EmployerRegister;

public class EmployerRegisterValidation : AbstractValidator<EmployerRegisterCommand>
{
    public EmployerRegisterValidation()
    {
        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is invalid.");

        RuleFor(e => e.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");

        RuleFor(e => e.ConfirmPassword)
            .NotEmpty().WithMessage("Confirm Password is required.")
            .Equal(e => e.Password).WithMessage("Password and Confirm Password must match.");

        RuleFor(e => e.FirstName)
            .NotEmpty().WithMessage("First Name is required.")
            .MaximumLength(50).WithMessage("First Name must not exceed 50 characters.");

        RuleFor(e => e.LastName)
            .NotEmpty().WithMessage("Last Name is required.")
            .MaximumLength(50).WithMessage("Last Name must not exceed 50 characters.");
    }
}