using Application.Abstractions;

namespace Application.Features.Commands.AdminCommands.UpdateAdmin;

public sealed record UpdateAdminCommand
    (int Id, string FirstName, string LastName) : ICommand;