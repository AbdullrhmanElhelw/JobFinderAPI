using FluentValidation;

namespace Application.Features.Commands.ApplicantCommands.DeleteExperience;

public class DeleteExperienceValidation : AbstractValidator<DeleteExperienceCommand>
{
    public DeleteExperienceValidation()
    {
        RuleFor(x => x.ApplicantId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0).WithMessage("{PropertyName} is required.");

        RuleFor(x => x.ExperinceId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0).WithMessage("{PropertyName} is required.");
    }
}