using FluentValidation;

namespace Application.Features.Commands.ApplicantCommands.UpdateExperience;

public class UpdateExperienceValidation : AbstractValidator<UpdateExperienceCommand>
{
    public UpdateExperienceValidation()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(50).WithMessage("Title must not exceed 50 characters.");

        RuleFor(x => x.CompanyName)
            .NotEmpty().WithMessage("Company name is required.")
            .MaximumLength(50).WithMessage("Company name must not exceed 50 characters.");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Position is required.")
            .MaximumLength(50).WithMessage("Position must not exceed 50 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Start date is required.")
            .LessThan(x => x.EndDate).WithMessage("Start date must be less than end date.");

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate)
            .WithMessage("End date must be greater than start date.");
    }
}