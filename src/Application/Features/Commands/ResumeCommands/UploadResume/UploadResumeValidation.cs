using FluentValidation;

namespace Application.Features.Commands.ResumeCommands.UploadResume;

public class UploadResumeValidation : AbstractValidator<UploadResumeCommand>
{
    public UploadResumeValidation()
    {
        RuleFor(x => x.ApplicantId)
            .GreaterThan(0)
            .WithMessage("ApplicantId must be greater than 0");

        RuleFor(x => x.Resume)
            .NotNull()
            .WithMessage("Resume must not be null");

    }

}
