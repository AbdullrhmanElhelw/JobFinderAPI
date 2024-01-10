using FluentValidation;

namespace Application.Features.Commands.CompanyCommands.UpdateCompany;

public class UpdateCompanyValidation
    : AbstractValidator<UpdateCompanyCommand>
{
    public UpdateCompanyValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(50)
            .WithMessage("Name must not exceed 50 characters.");

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("Address is required.")
            .MaximumLength(50)
            .WithMessage("Address must not exceed 50 characters.");

        RuleFor(x => x.City)
            .NotEmpty()
            .WithMessage("City is required.")
            .MaximumLength(50)
            .WithMessage("City must not exceed 50 characters.");

        RuleFor(x => x.Country)
            .NotEmpty()
            .WithMessage("Country is required.")
            .MaximumLength(50)
            .WithMessage("Country must not exceed 50 characters.");
    }
}