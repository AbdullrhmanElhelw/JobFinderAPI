using Application.Abstractions;

namespace Application.Features.Commands.EmailCommands.UpdateEmail;

public sealed record UpdateEmailCommand
    (string Email, string NewEmail, string ConfirmNewEmail, string Password) : ICommand;