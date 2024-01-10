using Application.Abstractions;

namespace Application.Features.Commands.EmailCommands.ConfirmUpdatedEmail;

public sealed record ConfirmUpdatedEmailCommand
    (string OldEmail, string Email, string Token) : ICommand;