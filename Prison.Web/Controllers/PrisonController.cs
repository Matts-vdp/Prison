using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prison.Contracts.Commands.PrisonBuildings;
using Prison.Contracts.Queries.PrisonBuildings;

namespace Prison.Web.Controllers
{

    public class PrisonController : ApiControllerBase
    {
        public PrisonController(IMediator mediator) : base(mediator)
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> GetPrisons()
        {
            return await ExecuteRequest(new GetAllPrisonBuildingsQuery());
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrisonById(string id)
        {
            return await ExecuteRequest(new GetPrisonBuildingByIdQuery(Guid.Parse(id)));
        }
        
        [HttpPost]
        public async Task<IActionResult> PostPrison(AddPrisonBuildingCommand command) 
        {
            if (command == null) return BadRequest();
            return await ExecuteRequest(command);
        }
    }
}
