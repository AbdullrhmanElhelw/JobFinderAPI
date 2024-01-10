using Application.Abstractions;

namespace Application.Features.Commands.JobApplicationCommands.CreateJobApplication;

public sealed record CreateApplicationCommand
    (int JobId, int ApplicantId) : ICommand;