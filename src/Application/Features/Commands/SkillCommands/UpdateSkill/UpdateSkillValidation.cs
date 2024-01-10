using FluentValidation;

namespace Application.Features.Commands.SkillCommands.UpdateSkill;

public class UpdateSkillValidation : AbstractValidator<UpdateSkillCommand>
{
    public UpdateSkillValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .GreaterThan(0).WithMessage("Id must be greater than 0");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MinimumLength(3).WithMessage("Description must be at least 3 characters long");
    }
}
