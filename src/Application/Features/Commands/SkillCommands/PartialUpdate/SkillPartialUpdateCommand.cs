using Application.Abstractions;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Features.Commands.SkillCommands.PartialUpdate;

public sealed record SkillPartialUpdateCommand
    (int Id, JsonPatchDocument SkillPD) : ICommand;