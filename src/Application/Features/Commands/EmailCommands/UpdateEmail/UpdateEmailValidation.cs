using FluentValidation;

namespace Application.Features.Commands.EmailCommands.UpdateEmail;

public class UpdateEmailValidation : AbstractValidator<UpdateEmailCommand>
{
    public UpdateEmailValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.NewEmail)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.ConfirmNewEmail)
            .NotEmpty()
            .EmailAddress()
            .Equal(x => x.NewEmail);

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}