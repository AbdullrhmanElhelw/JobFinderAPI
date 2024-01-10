using FluentValidation;

namespace Application.Features.Commands.ApplicantSkills;

public class CreateSkillValidation : AbstractValidator<CreateSkillCommand>
{
    public CreateSkillValidation()
    {
        RuleFor(x => x.ApplicantId)
            .GreaterThan(0)
            .WithMessage("Applicant Id must be greater than 0");

        RuleFor(x => x.SkillId)
            .GreaterThan(0)
            .WithMessage("Skill Id must be greater than 0");
    }
}