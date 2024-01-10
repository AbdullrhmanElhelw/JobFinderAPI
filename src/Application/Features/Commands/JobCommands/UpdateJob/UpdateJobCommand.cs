using Application.Abstractions;

namespace Application.Features.Commands.JobCommands.UpdateJob;

public sealed record UpdateJobCommand
    (int Id, string Title, string Description, int EmployerId) : ICommand;