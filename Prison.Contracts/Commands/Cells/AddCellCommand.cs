using FluentValidation;
using Prison.Contracts.Dtos;

namespace Prison.Contracts.Commands.Cells;

public class AddCellCommandValidator : AbstractValidator<AddCellCommand>
{
    public AddCellCommandValidator()
    {
        RuleFor(c => c.Capacity).NotEmpty().LessThan(4).GreaterThan(0);
        RuleFor(c => c.PrisonId).NotEmpty();
    } 
}

public class AddCellCommand : CommandBase<CellDto>
{
    public int Capacity { get; set; }
    public bool IsIsolation { get; set; } = false;
    public Guid PrisonId { get; set; }
}