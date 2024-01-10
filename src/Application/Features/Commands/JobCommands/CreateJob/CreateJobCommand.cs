using Application.Abstractions;

namespace Application.Features.Commands.JobCommands.CreateJob;

public sealed record CreateJobCommand
    (string Title, string Description, int EmployerId, int CompanyId) : ICommand;