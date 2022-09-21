using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prison.Contracts.Commands.Cells;
using Prison.Contracts.Queries.Cells;

namespace Prison.Web.Controllers;

public class CellController : ApiControllerBase
{
    public CellController(IMediator mediator) : base(mediator)
    {
            
    }

    [HttpGet]
    public async Task<IActionResult> GetCells()
    {
        return await ExecuteRequest(new GetAllCellsQuery());
    }
        
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCellById(string id)
    {
        return await ExecuteRequest(new GetCellByIdQuery(Guid.Parse(id)));
    }
    
    [HttpPost]
    public async Task<IActionResult> PostCell(AddCellCommand command) 
    {
        if (command == null) return BadRequest();
        return await ExecuteRequest(command);
    }
    
}