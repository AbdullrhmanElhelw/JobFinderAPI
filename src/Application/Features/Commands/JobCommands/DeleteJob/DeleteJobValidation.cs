using FluentValidation;

namespace Application.Features.Commands.JobCommands.DeleteJob;

public class DeleteJobValidation : AbstractValidator<DeleteJobCommand>
{
    public DeleteJobValidation()
    {
        RuleFor(v => v.JobId).NotEmpty().WithMessage("Id is required");
    }
}