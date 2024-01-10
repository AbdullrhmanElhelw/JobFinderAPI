using Application.Abstractions;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Features.Commands.ApplicantCommands.PartialUpdate;

public sealed record PartialUpdateApplicantCommand
    (string Email, JsonPatchDocument ApplicantPD) : ICommand;