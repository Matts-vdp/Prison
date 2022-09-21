using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Prison.Contracts.Commands.Cells;
using Prison.Contracts.Dtos;
using Prison.Contracts.Exceptions;
using Prison.Models.Entities;
using Prison.Repositories.Base;

namespace Prison.Application.CommandHandlers.Cells;

internal class AddCellsCommandHandler : IRequestHandler<AddCellCommand, CellDto>
{
    private readonly IRepository<Cell> _repository;
    private readonly IRepository<PrisonBuilding> _prisonRepo;

    public AddCellsCommandHandler(IRepository<Cell> repository, IRepository<PrisonBuilding> prisonRepo)
    {
        this._repository = repository;
        _prisonRepo = prisonRepo;
    }

    public async Task<CellDto> Handle(AddCellCommand request, CancellationToken cancellationToken)
    {
        ValidationResult result = await new AddCellCommandValidator().ValidateAsync(request);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        Cell cell = new Cell(request.Capacity, request.IsIsolation);
        _repository.Add(cell);


        PrisonBuilding prison = await _prisonRepo.GetAsync(p => p.Id == request.PrisonId && p.IsDeleted == false);
        prison.Add(cell);

        await _repository.SaveChangesAsync();
        await _prisonRepo.SaveChangesAsync();

        return CellDto.FromCell(cell);
    }
}

