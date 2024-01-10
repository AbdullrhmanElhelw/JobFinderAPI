using Application.DTOs.CompanyDTOs;

namespace Application.Features.Queries.CompanyQueries.GetAllCompaniesWithJobs;

public record GetAllCompaniesWithJobsResponse
     (int Id, string Name, string Description, string Country, string City, string Address, string Email, IEnumerable<ReadJobOfCompanyDTO> Jobs);