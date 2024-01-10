using FluentValidation;

namespace Application.Features.Commands.SkillCommands.DeleteSkill;

public class DeleteSkillValidation : AbstractValidator<DeleteSkillCommand>
{
    public DeleteSkillValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
    }
}