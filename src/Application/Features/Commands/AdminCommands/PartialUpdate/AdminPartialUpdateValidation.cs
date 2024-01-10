using FluentValidation;

namespace Application.Features.Commands.AdminCommands.PartialUpdate;

public class AdminPartialUpdateValidation : AbstractValidator<AdminPartialUpdateCommand>
{
    public AdminPartialUpdateValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .EmailAddress().WithMessage("{PropertyName} must be a valid email address.");

        RuleFor(x => x.AdminPD)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
    }
}