using Prison.Contracts.Dtos;

namespace Prison.Contracts.Queries.PrisonBuildings;

public class GetPrisonBuildingByIdQuery : QueryBase<PrisonBuildingDto>
{
    public Guid Id { get; set; }

    public GetPrisonBuildingByIdQuery(Guid id)
    {
        Id = id;
    }
}