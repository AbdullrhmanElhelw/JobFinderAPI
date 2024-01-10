using FluentValidation;

namespace Application.Features.Commands.ApplicantCommands.PartialUpdate;

public class PartialUpdateApplicantValidation : AbstractValidator<PartialUpdateApplicantCommand>
{
    public PartialUpdateApplicantValidation()
    {
        RuleFor(x => x.ApplicantPD).NotNull();
        RuleFor(x => x.Email).NotNull().EmailAddress();
    }
}