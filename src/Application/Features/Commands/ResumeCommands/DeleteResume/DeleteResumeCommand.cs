using Application.Abstractions;

namespace Application.Features.Commands.ResumeCommands.DeleteResume;

public sealed record DeleteResumeCommand
    (int ApplicantId, int ResumeId) : ICommand;
