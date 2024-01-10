using Application.Abstractions;

namespace Application.Features.Queries.AdminQueries.GetAllAdmins;

public sealed record GetAllAdminsQuery
    () : IQuery<IQueryable<GetAllAdminsResponse>>;