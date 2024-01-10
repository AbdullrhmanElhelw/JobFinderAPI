using FluentValidation;

namespace Application.Features.Commands.ApplicantCommands.ApplicantLogin;

public class ApplicantLoginCommandValidation : AbstractValidator<ApplicantLoginCommand>
{
    public ApplicantLoginCommandValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}
