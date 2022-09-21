using FluentValidation;
using Prison.Contracts.Dtos;
using Prison.Models.Entities;

namespace Prison.Contracts.Commands.Prisoners;

public class AddPrisonerCommandValidator : AbstractValidator<AddPrisonerCommand>
{
    public AddPrisonerCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.IsMale).NotEmpty();
        RuleFor(c => c.PType).NotEmpty();
        RuleFor(c => c.WhenFree).NotEmpty();
        RuleFor(c => c.PrisonId).NotEmpty();
    } 
}

public class AddPrisonerCommand : CommandBase<PrisonerDto>
{
    public string Name { get; set; }
    public bool IsMale { get; set; }
    public string PType { get; set; }
    public DateTime WhenFree { get; set; }
    public Guid PrisonId { get; set; }
}