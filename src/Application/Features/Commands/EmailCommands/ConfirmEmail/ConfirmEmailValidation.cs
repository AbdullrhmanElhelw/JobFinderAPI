using Application.Features.Commands.EmailCommands.ComfirmEmail;
using FluentValidation;

namespace Application.Features.Commands.EmailCommands.ConfirmEmail;

public class ConfirmEmailValidation : AbstractValidator<ConfirmEmailCommand>
{
    public ConfirmEmailValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Token)
            .NotEmpty();
    }
}