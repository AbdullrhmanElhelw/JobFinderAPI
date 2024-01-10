using Application.Abstractions;

namespace Application.Features.Commands.AdminCommands.AdminLogout;

public sealed record AdminLogoutCommand
    (int AdminId, string AdminToken) : ICommand;