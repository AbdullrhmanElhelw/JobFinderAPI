using FluentValidation;

namespace Application.Features.Commands.EmployerCommands.DeleteEmployer;

public class DeleteEmployerValidation : AbstractValidator<DeleteEmployerCommand>
{
    public DeleteEmployerValidation()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id must be greater than 0");
    }
}