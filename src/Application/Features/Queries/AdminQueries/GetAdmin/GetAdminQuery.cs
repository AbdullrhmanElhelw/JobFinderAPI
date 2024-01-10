using Application.Abstractions;

namespace Application.Features.Queries.AdminQueries.GetAdmin;

public sealed record GetAdminQuery
    (int Id) : IQuery<GetAdminResponse>;