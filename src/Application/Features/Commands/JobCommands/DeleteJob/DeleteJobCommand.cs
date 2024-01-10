using Application.Abstractions;

namespace Application.Features.Commands.JobCommands.DeleteJob;

public sealed record DeleteJobCommand
    (int JobId) : ICommand;