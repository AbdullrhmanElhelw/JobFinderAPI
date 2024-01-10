using FluentValidation;

namespace Application.Features.Commands.CompanyCommands.DeleteCompany;

public class DeleteCompanyValidation : AbstractValidator<DeleteCompanyCommand>
{
    public DeleteCompanyValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id Should be Greater than Zero.");
    }
}