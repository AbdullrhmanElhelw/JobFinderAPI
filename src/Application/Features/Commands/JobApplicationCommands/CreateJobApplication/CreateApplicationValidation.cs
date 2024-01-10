using FluentValidation;

namespace Application.Features.Commands.JobApplicationCommands.CreateJobApplication;

public class CreateApplicationValidation : AbstractValidator<CreateApplicationCommand>
{
    public CreateApplicationValidation()
    {
        RuleFor(x => x.JobId)
            .GreaterThan(0)
            .WithMessage("JobId must be greater than 0");

        RuleFor(x => x.ApplicantId)
            .GreaterThan(0)
            .WithMessage("ApplicantId must be greater than 0");
    }
}
