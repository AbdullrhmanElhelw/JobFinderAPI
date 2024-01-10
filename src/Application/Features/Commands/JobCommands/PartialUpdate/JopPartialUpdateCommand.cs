using Application.Abstractions;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Features.Commands.JobCommands.PartialUpdate;

public record JopPartialUpdateCommand
    (int Id, JsonPatchDocument JobPD) : ICommand;