using Application.DapperQueries.QueryBase;
using Application.DTOs.JobDTOs;
using Domain.Models;

namespace Application.DapperQueries.JobQueries;

public interface IJobQuery : IQueryBase<ReadJobDTO>
{
    Task<IQueryable<ReadJobDTO>> FindJob(string Filter);

    Task<Job?> GetToDelete(int Id);

    Task<UpdateJobDTO?> GetToUpdate(int Id);

    Task<IQueryable<ReadJobDTO>> GetWithPaging(int pageSize, int pageNumber, string filter = "");
}