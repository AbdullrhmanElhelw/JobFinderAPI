using Application.Abstractions;

namespace Application.Features.Commands.ApplicantCommands.ApplicantLogin;

public sealed record ApplicantLoginCommand
    (string Email, string Password) : ICommand<string>;
