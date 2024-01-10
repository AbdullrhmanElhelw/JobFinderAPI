using Application.Abstractions;

namespace Application.Features.Commands.AdminCommands.DeleteAdmin;

public sealed record DeleteAdminCommand
    (int Id) : ICommand;