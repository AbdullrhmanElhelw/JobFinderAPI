using Application.Abstractions;

namespace Application.Features.Commands.CompanyCommands.CompanyLogin;

public sealed record CompanyLoginCommand
    (string Email, string Password) : ICommand<string>;