using Application.DapperQueries.QueryBase;
using Application.DTOs.ApplicantDTOs;

namespace Application.DapperQueries.ApplicantQueries;

public interface IApplicantQuery : IQueryBase<ReadApplicantDTO>
{
    Task<ReadApplicantWithJobsDTO?> GetApplicantWithJobs(int Id);
}