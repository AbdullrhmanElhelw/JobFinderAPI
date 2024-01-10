using Application.Abstractions;
using Application.DapperQueries.AdminQueries;
using Domain.Shared;

namespace Application.Features.Queries.AdminQueries.GetAdmin;

public sealed class GetAdminQueryHandler(IAdminQuery adminQuery)
    : IQueryHandler<GetAdminQuery, GetAdminResponse>
{
    private readonly IAdminQuery _adminQuery = adminQuery;

    public async Task<Result<GetAdminResponse>> Handle(GetAdminQuery request, CancellationToken cancellationToken)
    {
        var adminExists = await adminQuery.Get(request.Id);

        return adminExists is null
            ? Result.Fail<GetAdminResponse>($"Admin with id {request.Id} does not exist")
            : Result.Ok(new GetAdminResponse(adminExists.Id, adminExists.AdminName));
    }
}