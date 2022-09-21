using Prison.Contracts.Dtos;

namespace Prison.Contracts.Queries.Cells;

public class GetCellByIdQuery : QueryBase<CellDto>
{
    public Guid Id { get; set; }

    public GetCellByIdQuery(Guid id)
    {
        Id = id;
    }
}