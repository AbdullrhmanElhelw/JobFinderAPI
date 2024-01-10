using FluentValidation;

namespace Application.Features.Commands.JobCommands.PartialUpdate;

internal class JopPartialUpdateValidation : AbstractValidator<JopPartialUpdateCommand>
{
    public JopPartialUpdateValidation()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.JobPD).NotNull();
    }
}