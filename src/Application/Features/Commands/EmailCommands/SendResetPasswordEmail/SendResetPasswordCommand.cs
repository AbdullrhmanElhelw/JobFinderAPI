using Application.Abstractions;

namespace Application.Features.Commands.EmailCommands.SendResetPasswordEmail;

public sealed record SendResetPasswordCommand
    (string Email) : ICommand;