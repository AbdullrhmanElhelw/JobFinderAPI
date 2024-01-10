using Application.Abstractions;

namespace Application.Features.Queries.EmployerQueries.GetEmployerById;

public sealed record GetEmployerByIdQuery
    (int Id) : IQuery<GetEmployerByIdResponse>;