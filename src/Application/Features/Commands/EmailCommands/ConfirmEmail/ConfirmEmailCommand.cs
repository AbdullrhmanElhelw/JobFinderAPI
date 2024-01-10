using Application.Abstractions;

namespace Application.Features.Commands.EmailCommands.ComfirmEmail;

public sealed record ConfirmEmailCommand
    (string Email, string Token) : ICommand;