using Domain.Shared;
using MediatR;

namespace Application.Abstractions;

public interface IQuery : IRequest<Result>
{
}

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}