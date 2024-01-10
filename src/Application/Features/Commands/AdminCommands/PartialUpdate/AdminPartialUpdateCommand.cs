using Application.Abstractions;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Features.Commands.AdminCommands.PartialUpdate;

public sealed record AdminPartialUpdateCommand
    (string Email, JsonPatchDocument AdminPD) : ICommand;