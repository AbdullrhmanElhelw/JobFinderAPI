using Application.Abstractions;

namespace Application.Features.Commands.CompanyCommands.CompanyRegistration;

public sealed record CompanyRegistrationCommand
    (string Name, string Email, string Password, string ConfirmPassword, string Address, string City, string Country)
    : ICommand;