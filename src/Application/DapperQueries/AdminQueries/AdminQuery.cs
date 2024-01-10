using Application.DTOs.AdminDTOs;
using Dapper;

namespace Application.DapperQueries.AdminQueries;

internal class AdminQuery(DapperDbContext context)
    : IAdminQuery
{
    private readonly DapperDbContext _context = context;

    public async Task<ReadAdminDTO?> Get(int Id)
    {
        using var connection = _context.CreateConnection();
        var sql = "EXEC GetAdmin @Id";
        var admin = await connection.QueryFirstOrDefaultAsync<ReadAdminDTO>(sql, new { Id });
        return admin;
    }

    public async Task<IQueryable<ReadAdminDTO>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = "SELECT * FROM [dbo].[GetAllAdmins]";
        var admins = await connection.QueryAsync<ReadAdminDTO>(sql);
        return admins.AsQueryable();
    }

    public async Task<IQueryable<ReadAdminDTO>> GetAllWithPaging(int pageSize, int pageNumber)
    {
        using var connection = _context.CreateConnection();
        var sql = "EXEC [dbo].[GetAllAdminsWithPaging] @PageSize, @PageNumber";
        var admins = await connection.QueryAsync<ReadAdminDTO>(sql, new { PageSize = pageSize, PageNumber = pageNumber });
        return admins.AsQueryable();
    }
}