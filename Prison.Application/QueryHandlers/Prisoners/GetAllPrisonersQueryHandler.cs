using MediatR;
using Prison.Contracts.Dtos;
using Prison.Contracts.Exceptions;
using Prison.Contracts.Queries.Prisoners;
using Prison.Models.Entities;
using Prison.Repositories.Base;

namespace Prison.Application.QueryHandlers.Prisoners;

internal class GetAllPrisonersQueryHandler : IRequestHandler<GetAllPrisonersQuery, IEnumerable<PrisonerDto>>
{
    private readonly IRepository<Prisoner> _repository;

    public GetAllPrisonersQueryHandler(IRepository<Prisoner> repository)
    {
        this._repository = repository;
    }

    public async Task<IEnumerable<PrisonerDto>> Handle(GetAllPrisonersQuery request, CancellationToken cancellationToken)
    {
        var prisoners = await _repository.GetListAsync(p => p.IsDeleted == false);
        if (prisoners == null)
        {
            throw new NotFoundException("Nothing found");
        }
        return PrisonerDto.FromPrisoners(prisoners);
    }

}
