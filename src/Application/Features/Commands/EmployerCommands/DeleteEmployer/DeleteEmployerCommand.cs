using Application.Abstractions;

namespace Application.Features.Commands.EmployerCommands.DeleteEmployer;

public sealed record DeleteEmployerCommand
    (int Id) : ICommand;