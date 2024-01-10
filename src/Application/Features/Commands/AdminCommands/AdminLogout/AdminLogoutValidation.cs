using FluentValidation;

namespace Application.Features.Commands.AdminCommands.AdminLogout;

internal class AdminLogoutValidation : AbstractValidator<AdminLogoutCommand>
{
    public AdminLogoutValidation()
    {
        RuleFor(x => x.AdminId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.AdminToken)
            .NotEmpty()
            .NotNull();
    }
}