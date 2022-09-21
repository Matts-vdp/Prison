using FluentValidation;
using Prison.Contracts.Dtos;

namespace Prison.Contracts.Commands.PrisonBuildings;

public class AddPrisonBuildingCommandValidator : AbstractValidator<AddPrisonBuildingCommand>
{
    public AddPrisonBuildingCommandValidator()
    {
        RuleFor(c => c.Capacity).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    } 
}

public class AddPrisonBuildingCommand : CommandBase<PrisonBuildingDto>
{
    public string Name { get; set; }
    public int Capacity { get; set; }
}