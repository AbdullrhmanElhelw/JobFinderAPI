using Application.Abstractions;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Features.Commands.CompanyCommands.PartialUpdate;

public sealed record CompanyPartialUpdateCommand
    (string Email, JsonPatchDocument CompanyPD) : ICommand;