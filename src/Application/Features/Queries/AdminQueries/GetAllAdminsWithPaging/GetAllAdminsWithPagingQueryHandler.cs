using Application.Abstractions;
using Application.DapperQueries.AdminQueries;
using Domain.Shared;

namespace Application.Features.Queries.AdminQueries.GetAllAdminsWithPaging;

public sealed class GetAllAdminsWithPagingQueryHandler(IAdminQuery adminQuery)
    : IQueryHandler<GetAllAdminsWithPagingQuery, IQueryable<GetAllAdminsWithPagingResponse>>
{
    private readonly IAdminQuery _adminQuery = adminQuery;

    public async Task<Result<IQueryable<GetAllAdminsWithPagingResponse>>> Handle(GetAllAdminsWithPagingQuery request, CancellationToken cancellationToken)
    {
        var adminList = await _adminQuery.GetAllWithPaging(request.PageNumber, request.PageSize);
        var adminListResponse = adminList.Select
            (admin => new GetAllAdminsWithPagingResponse(admin.Id, admin.AdminName));
        return Result.Ok(adminListResponse);
    }
}