using FluentValidation;

namespace Application.Features.Commands.EmailCommands.SendResetPasswordEmail;

internal class SendResetPasswordValidation : AbstractValidator<SendResetPasswordCommand>
{
    public SendResetPasswordValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress().WithMessage("Email is not valid");
    }
}