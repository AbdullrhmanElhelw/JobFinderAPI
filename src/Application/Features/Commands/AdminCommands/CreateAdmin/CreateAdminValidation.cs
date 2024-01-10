using FluentValidation;

namespace Application.Features.Commands.AdminCommands.CreateAdmin;

public class CreateAdminValidation : AbstractValidator<CreateAdminCommand>
{
    public CreateAdminValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8);

        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(2);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MinimumLength(2);
    }
}