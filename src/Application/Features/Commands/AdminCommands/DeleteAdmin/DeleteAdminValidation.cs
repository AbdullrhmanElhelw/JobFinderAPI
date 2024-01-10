using FluentValidation;

namespace Application.Features.Commands.AdminCommands.DeleteAdmin;

public class DeleteAdminValidation : AbstractValidator<DeleteAdminCommand>
{
    public DeleteAdminValidation()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id must be greater than 0");
    }
}