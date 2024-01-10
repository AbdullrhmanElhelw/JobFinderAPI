using FluentValidation;

namespace Application.Features.Commands.ResumeCommands.DeleteResume;

public class DeleteResumeValidation : AbstractValidator<DeleteResumeCommand>
{
    public DeleteResumeValidation()
    {
        RuleFor(x => x.ApplicantId)
            .GreaterThan(0)
            .WithMessage("ApplicantId must be greater than 0");

        RuleFor(x => x.ResumeId)
            .GreaterThan(0)
            .WithMessage("ResumeId must be greater than 0");
    }
}
