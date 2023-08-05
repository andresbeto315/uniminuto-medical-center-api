using Application.UsesCase.State.GetAllState;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [Route("all")]
        public IActionResult GetAll()
        {
            var request = new GetAllStateRequest();
            return Ok(_mediator.Send(request).Result);
        }
    }
}