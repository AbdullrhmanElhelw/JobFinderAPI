using FluentValidation;

namespace Application.Features.Commands.ApplicantCommands.DeleteSkill;

public class DeleteSkillValidation : AbstractValidator<DeleteApplicantSkillCommand>
{
    public DeleteSkillValidation()
    {
        RuleFor(p => p.SkillId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();

        RuleFor(p => p.ApplicantId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
    }
}
