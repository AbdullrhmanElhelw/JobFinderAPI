using Application.DapperQueries.QueryBase;
using Application.DTOs.AdminDTOs;

namespace Application.DapperQueries.AdminQueries;

public interface IAdminQuery : IQueryBase<ReadAdminDTO>
{
    Task<IQueryable<ReadAdminDTO>> GetAllWithPaging(int pageSize, int pageNumber);
}