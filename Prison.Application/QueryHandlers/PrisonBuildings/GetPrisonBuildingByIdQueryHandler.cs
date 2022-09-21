using MediatR;
using Prison.Contracts.Dtos;
using Prison.Contracts.Exceptions;
using Prison.Contracts.Queries.PrisonBuildings;
using Prison.Models.Entities;
using Prison.Repositories.Base;

namespace Prison.Application.QueryHandlers.PrisonBuildings;

public class GetPrisonBuildingByIdQueryHandler : IRequestHandler<GetPrisonBuildingByIdQuery, PrisonBuildingDto>
{
    private readonly IRepository<PrisonBuilding> _repository;

    public GetPrisonBuildingByIdQueryHandler(IRepository<PrisonBuilding> repository)
    {
        this._repository = repository;
    }
    
    public async Task<PrisonBuildingDto> Handle(GetPrisonBuildingByIdQuery request, CancellationToken cancellationToken)
    {
        var prisonBuilding = await _repository.GetAsync(p => p.IsDeleted == false && p.Id == request.Id);
        if (prisonBuilding == null)
        {
            throw new NotFoundException("Nothing found");
        }

        return PrisonBuildingDto.FromPrisonBuilding(prisonBuilding);
    }
}