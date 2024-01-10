using FluentValidation;

namespace Application.Features.Commands.SkillCommands.PartialUpdate;

public class SkillPartialUpdateValidation : AbstractValidator<SkillPartialUpdateCommand>
{
    public SkillPartialUpdateValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .NotNull();

        RuleFor(x => x.SkillPD)
            .NotEmpty().WithMessage("Skill Patch Document is required")
            .NotNull();
    }
}