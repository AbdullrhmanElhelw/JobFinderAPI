using FluentValidation;

namespace Application.Features.Commands.AdminCommands.UpdateAdmin;

public class UpdateAdminValidation : AbstractValidator<UpdateAdminCommand>
{
    public UpdateAdminValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .NotNull().WithMessage("Id is required");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("FirstName is required")
            .NotNull().WithMessage("FirstName is required")
            .MinimumLength(3).WithMessage("FirstName must be at least 3 characters");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("LastName is required")
            .NotNull().WithMessage("LastName is required")
            .MinimumLength(3).WithMessage("LastName must be at least 3 characters");
    }
}