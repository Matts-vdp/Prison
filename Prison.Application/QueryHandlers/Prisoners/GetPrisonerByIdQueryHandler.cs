using MediatR;
using Prison.Contracts.Dtos;
using Prison.Contracts.Exceptions;
using Prison.Contracts.Queries.Prisoners;
using Prison.Models.Entities;
using Prison.Repositories.Base;

namespace Prison.Application.QueryHandlers.Prisoners;

public class GetPrisonerByIdQueryHandler : IRequestHandler<GetPrisonerByIdQuery, PrisonerDto>
{
    private readonly IRepository<Prisoner> _repository;

    public GetPrisonerByIdQueryHandler(IRepository<Prisoner> repository)
    {
        this._repository = repository;
    }
    
    public async Task<PrisonerDto> Handle(GetPrisonerByIdQuery request, CancellationToken cancellationToken)
    {
        var prisoner = await _repository.GetAsync(p => p.IsDeleted == false && p.Id == request.Id);
        if (prisoner == null)
        {
            throw new NotFoundException("Nothing found");
        }

        return PrisonerDto.FromPrisoner(prisoner);
    }
}