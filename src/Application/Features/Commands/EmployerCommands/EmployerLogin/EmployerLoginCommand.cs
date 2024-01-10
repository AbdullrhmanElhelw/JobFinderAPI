using Application.Abstractions;

namespace Application.Features.Commands.EmployerCommands.EmployerLogin;

public sealed record EmployerLoginCommand
    (string Email, string Password) : ICommand;