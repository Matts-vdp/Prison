using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prison.Contracts.Commands.Prisoners;
using Prison.Contracts.Queries.Prisoners;

namespace Prison.Web.Controllers;

public class PrisonerController : ApiControllerBase
{
    public PrisonerController(IMediator mediator) : base(mediator)
    {
            
    }

    [HttpGet]
    public async Task<IActionResult> GetPrisoners()
    {
        return await ExecuteRequest(new GetAllPrisonersQuery());
    }
        
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPrisonerById(string id)
    {
        return await ExecuteRequest(new GetPrisonerByIdQuery(Guid.Parse(id)));
    }
    
    [HttpPost]
    public async Task<IActionResult> PostPrisoner(AddPrisonerCommand command) 
    {
        if (command == null) return BadRequest();
        return await ExecuteRequest(command);
    }
}