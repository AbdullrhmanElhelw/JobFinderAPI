using Application.Abstractions;

namespace Application.Features.Commands.CompanyCommands.UpdateCompany;

public sealed record UpdateCompanyCommand
    (int Id, string Name, string Address, string City, string Country)
    : ICommand;