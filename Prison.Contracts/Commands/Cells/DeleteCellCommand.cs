using FluentValidation;
using Prison.Contracts.Dtos;

namespace Prison.Contracts.Commands.Cells;

public class DeleteCellCommandValidator : AbstractValidator<DeleteCellCommand>
{
    public DeleteCellCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    } 
}

public class DeleteCellCommand : CommandBase<CellDto>
{
    public Guid Id { get; set; }
}