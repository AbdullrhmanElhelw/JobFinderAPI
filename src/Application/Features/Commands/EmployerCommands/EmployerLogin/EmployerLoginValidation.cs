using FluentValidation;

namespace Application.Features.Commands.EmployerCommands.EmployerLogin;

public class EmployerLoginValidation : AbstractValidator<EmployerLoginCommand>
{
    public EmployerLoginValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress().WithErrorCode("Invalid Email Address");

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}