using Application.Abstractions;

namespace Application.Features.Commands.ApplicantCommands.UpdateApplicant;

public sealed record UpdateApplicantCommand
    (int Id, string FirstName, string LastName) : ICommand;
