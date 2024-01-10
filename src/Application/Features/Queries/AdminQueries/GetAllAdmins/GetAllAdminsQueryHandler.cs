using Application.Abstractions;
using Application.DapperQueries.AdminQueries;
using Domain.Shared;

namespace Application.Features.Queries.AdminQueries.GetAllAdmins;

public sealed class GetAllAdminsQueryHandler(IAdminQuery adminQuery)
    : IQueryHandler<GetAllAdminsQuery, IQueryable<GetAllAdminsResponse>>
{
    private readonly IAdminQuery _adminQuery = adminQuery;

    public async Task<Result<IQueryable<GetAllAdminsResponse>>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
    {
        var adminlist = await _adminQuery.GetAll();
        var adminlistResponse = adminlist.Select(admin => new GetAllAdminsResponse(admin.Id, admin.AdminName));
        return Result.Ok(adminlistResponse);
    }
}