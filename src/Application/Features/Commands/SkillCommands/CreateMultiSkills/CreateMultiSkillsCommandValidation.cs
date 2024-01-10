using FluentValidation;

namespace Application.Features.Commands.SkillCommands.CreateMultiSkills;

public class CreateMultiSkillsCommandValidation : AbstractValidator<CreateMultiSkillsCommand>
{
    public CreateMultiSkillsCommandValidation()
    {
        RuleForEach(x => x.Skills)
            .ChildRules(x =>
            {
                x.RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Name is required.")
                    .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

                x.RuleFor(x => x.Description)
                    .NotEmpty().WithMessage("Description is required.")
                    .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

                x.RuleFor(x => x.Level)
                    .IsInEnum().WithMessage("Level must be a valid SkillLevel.");
            });
    }
}