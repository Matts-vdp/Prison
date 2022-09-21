using MediatR;

namespace Prison.Contracts.Commands;

public class CommandBase<T> : IRequest<T> where T : class
{

}
