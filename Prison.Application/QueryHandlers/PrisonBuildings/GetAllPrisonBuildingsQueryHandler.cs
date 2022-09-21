using MediatR;
using Prison.Contracts.Dtos;
using Prison.Contracts.Exceptions;
using Prison.Contracts.Queries.PrisonBuildings;
using Prison.Models.Entities;
using Prison.Repositories.Base;

namespace Prison.Application.QueryHandlers.PrisonBuildings;

internal class GetAllPrisonBuildingsQueryHandler : IRequestHandler<GetAllPrisonBuildingsQuery, IEnumerable<PrisonBuildingDto>>
{
    private readonly IRepository<PrisonBuilding> _repository;

    public GetAllPrisonBuildingsQueryHandler(IRepository<PrisonBuilding> repository)
    {
        this._repository = repository;
    }

    public async Task<IEnumerable<PrisonBuildingDto>> Handle(GetAllPrisonBuildingsQuery request, CancellationToken cancellationToken)
    {
        var prisonBuildings = await _repository.GetListAsync(p => p.IsDeleted == false);
        if (prisonBuildings == null)
        {
            throw new NotFoundException("Nothing found");
        }
        return PrisonBuildingDto.FromPrisonBuildings(prisonBuildings);
    }

}
