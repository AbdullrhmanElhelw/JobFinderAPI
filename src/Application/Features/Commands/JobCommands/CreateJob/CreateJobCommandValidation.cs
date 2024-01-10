using FluentValidation;

namespace Application.Features.Commands.JobCommands.CreateJob;

public class CreateJobCommandValidation : AbstractValidator<CreateJobCommand>
{
    public CreateJobCommandValidation()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500);
    }
}