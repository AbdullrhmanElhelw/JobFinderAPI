using Application.Abstractions;

namespace Application.Features.Commands.CompanyCommands.DeleteCompany;

public sealed record DeleteCompanyCommand
    (int Id) : ICommand;