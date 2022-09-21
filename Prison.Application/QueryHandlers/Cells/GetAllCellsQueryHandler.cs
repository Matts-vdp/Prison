using MediatR;
using Prison.Contracts.Dtos;
using Prison.Contracts.Exceptions;
using Prison.Contracts.Queries.Cells;
using Prison.Models.Entities;
using Prison.Repositories.Base;

namespace Prison.Application.QueryHandlers.Cells;

internal class GetAllCellsQueryHandler : IRequestHandler<GetAllCellsQuery, IEnumerable<CellDto>>
{
    private readonly IRepository<Cell> _repository;

    public GetAllCellsQueryHandler(IRepository<Cell> repository)
    {
        this._repository = repository;
    }

    public async Task<IEnumerable<CellDto>> Handle(GetAllCellsQuery request, CancellationToken cancellationToken)
    {
        var cells = await _repository.GetListAsync(c => c.IsDeleted == false);
        if (cells == null)
        {
            throw new NotFoundException("Nothing found");
        }
        return CellDto.FromCells(cells);
    }
}
