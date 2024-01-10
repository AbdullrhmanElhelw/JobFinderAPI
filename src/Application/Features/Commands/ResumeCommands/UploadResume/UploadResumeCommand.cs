using Application.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Commands.ResumeCommands.UploadResume;

public record UploadResumeCommand
    (int ApplicantId, IFormFile Resume) : ICommand;