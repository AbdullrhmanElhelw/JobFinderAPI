using FluentValidation;

namespace Application.Features.Commands.EmailCommands.ConfirmUpdatedEmail;

public class ConfirmUpdatedEmailValidation : AbstractValidator<ConfirmUpdatedEmailCommand>
{
    public ConfirmUpdatedEmailValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Token)
            .NotEmpty();
    }
}