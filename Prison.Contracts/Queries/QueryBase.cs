using MediatR;

namespace Prison.Contracts.Queries;

public class QueryBase<T> : IRequest<T> where T : class
{
}
