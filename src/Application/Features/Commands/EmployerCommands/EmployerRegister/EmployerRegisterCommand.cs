using Application.Abstractions;

namespace Application.Features.Commands.EmployerCommands.EmployerRegister;

public sealed record EmployerRegisterCommand
    (string Email, string Password, string ConfirmPassword, string FirstName, string LastName, int CompanyId)
    : ICommand;