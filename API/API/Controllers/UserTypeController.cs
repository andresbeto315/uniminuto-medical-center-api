using Application.UsesCase.UserType.GetAllUserType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [Route("all")]
        public IActionResult GetAll()
        {
            var request = new GetAllUserTypeRequest();
            return Ok(_mediator.Send(request).Result);
        }
    }
}