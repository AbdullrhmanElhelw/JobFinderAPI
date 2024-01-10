using FluentValidation;

namespace Application.Features.Commands.CompanyCommands.PartialUpdate;

public class CompanyPartialUpdateValidation : AbstractValidator<CompanyPartialUpdateCommand>
{
    public CompanyPartialUpdateValidation()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.CompanyPD).NotNull();
    }
}