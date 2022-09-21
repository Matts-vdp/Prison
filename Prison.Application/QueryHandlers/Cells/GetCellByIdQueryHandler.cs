using MediatR;
using Prison.Contracts.Dtos;
using Prison.Contracts.Exceptions;
using Prison.Contracts.Queries.Cells;
using Prison.Models.Entities;
using Prison.Repositories.Base;

namespace Prison.Application.QueryHandlers.Cells;

public class GetCellByIdQueryHandler : IRequestHandler<GetCellByIdQuery, CellDto>
{
    private readonly IRepository<Cell> _repository;

    public GetCellByIdQueryHandler(IRepository<Cell> repository)
    {
        this._repository = repository;
    }
    
    public async Task<CellDto> Handle(GetCellByIdQuery request, CancellationToken cancellationToken)
    {
        var cell = await _repository.GetAsync(c => c.IsDeleted == false && c.Id == request.Id);
        if (cell == null)
        {
            throw new NotFoundException("Nothing found");
        }

        return CellDto.FromCell(cell);
    }
}