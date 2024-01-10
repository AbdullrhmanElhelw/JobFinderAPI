using Application.Abstractions;

namespace Application.Features.Commands.AdminCommands.ApplicantLogin;

public sealed record AdminLoginCommand
    (string Email, string Password)
    : ICommand;