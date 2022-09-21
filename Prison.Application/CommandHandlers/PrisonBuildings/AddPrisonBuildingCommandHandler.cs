using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Prison.Contracts.Commands.PrisonBuildings;
using Prison.Contracts.Dtos;
using Prison.Models.Entities;
using Prison.Repositories.Base;

namespace Prison.Application.CommandHandlers.PrisonBuildings;

internal class AddPrisonBuildingCommandHandler : IRequestHandler<AddPrisonBuildingCommand, PrisonBuildingDto>
{
    private readonly IRepository<PrisonBuilding> _repository;

    public AddPrisonBuildingCommandHandler(IRepository<PrisonBuilding> repository)
    {
        this._repository = repository;
    }
    public async Task<PrisonBuildingDto> Handle(AddPrisonBuildingCommand request, CancellationToken cancellationToken)
    {
        ValidationResult result = await new AddPrisonBuildingCommandValidator().ValidateAsync(request);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        PrisonBuilding prison = new PrisonBuilding(request.Name, request.Capacity);
        _repository.Add(prison);
        await _repository.SaveChangesAsync();

        return PrisonBuildingDto.FromPrisonBuilding(prison);
    }
}

