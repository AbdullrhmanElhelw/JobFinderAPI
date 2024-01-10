using Application.Abstractions;

namespace Application.Features.Commands.ApplicantCommands.ApplicantRegister;

public sealed record ApplicantRegisterCommand
    (string Email, string Password, string ConfirmPassword, string FirstName, string LastName, string Origin)
    : ICommand;