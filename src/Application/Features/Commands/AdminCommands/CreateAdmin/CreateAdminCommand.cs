using Application.Abstractions;

namespace Application.Features.Commands.AdminCommands.CreateAdmin;

public record CreateAdminCommand
    (string Email, string Password, string ConfirmPassword, string FirstName, string LastName)
    : ICommand;