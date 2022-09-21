using Prison.Contracts.Dtos;

namespace Prison.Contracts.Queries.Prisoners;

public class GetPrisonerByIdQuery : QueryBase<PrisonerDto>
{
    public Guid Id { get; set; }

    public GetPrisonerByIdQuery(Guid id)
    {
        Id = id;
    }
}