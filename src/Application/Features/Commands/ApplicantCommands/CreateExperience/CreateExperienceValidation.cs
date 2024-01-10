using FluentValidation;

namespace Application.Features.Commands.ApplicantCommands.CreateExperience;

public class CreateExperienceValidation : AbstractValidator<CreateExperienceCommand>
{
    public CreateExperienceValidation()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .NotNull()
            .MaximumLength(50).WithMessage("Title must not exceed 50 characters");

        RuleFor(x => x.Company)
            .NotEmpty().WithMessage("Company is required")
            .NotNull()
            .MaximumLength(50).WithMessage("Company must not exceed 50 characters");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required")
            .NotNull()
            .MaximumLength(50).WithMessage("Location must not exceed 50 characters");

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Start Date is required")
            .NotNull();

        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage("End Date is required")
            .NotNull();

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .NotNull()
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters");

        RuleFor(x => x.IsCurrent)
            .NotEmpty().WithMessage("Is Current is required")
            .NotNull();

        RuleFor(x => x.ApplicantId)
            .NotEmpty().WithMessage("Applicant Id is required")
            .NotNull();
    }
}