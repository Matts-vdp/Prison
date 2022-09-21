using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Prison.Contracts.Commands.Prisoners;
using Prison.Contracts.Dtos;
using Prison.Contracts.Exceptions;
using Prison.Models.Entities;
using Prison.Repositories.Base;

namespace Prison.Application.CommandHandlers.Prisoners;

internal class AddPrisonerCommandHandler : IRequestHandler<AddPrisonerCommand, PrisonerDto>
{
    private readonly IRepository<Prisoner> _repository;
    private readonly IRepository<Cell> _cellRepo;
    private readonly IRepository<PrisonBuilding> _prisonRepo;

    public AddPrisonerCommandHandler(IRepository<Prisoner> repository, IRepository<Cell> cellRepo, IRepository<PrisonBuilding> prisonRepo)
    {
        this._repository = repository;
        _cellRepo = cellRepo;
        _prisonRepo = prisonRepo;
    }
    public async Task<PrisonerDto> Handle(AddPrisonerCommand request, CancellationToken cancellationToken)
    {
        ValidationResult result = await new AddPrisonerCommandValidator().ValidateAsync(request);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        Prisoner prisoner = new Prisoner(request.Name, request.WhenFree, request.PType, request.IsMale);
        
        var prison = await _prisonRepo.GetAsync(p => p.Id == request.PrisonId && !p.IsDeleted);
        _repository.Add(prisoner);
        prison.Add(prisoner);

        await _repository.SaveChangesAsync();
        await _cellRepo.SaveChangesAsync();
        return PrisonerDto.FromPrisoner(prisoner);
    }
}

