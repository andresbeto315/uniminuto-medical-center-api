using Application.UsesCase.MedicalAppointment.GetByDoctorId;
using Application.UsesCase.MedicalAppointment.GetByPatientId;
using Application.UsesCase.MedicalAppointment.GetMedicalAppointmentById;
using Application.UsesCase.MedicalAppointment.RegisterMedicalAppointment;
using Application.UsesCase.MedicalAppointment.UpdateMedicalAppointment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalAppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicalAppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [Route("get-id")]
        public IActionResult GetById([FromQuery] GetMedicalAppointmentByIdRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpGet()]
        [Route("get-doctor")]
        public IActionResult GetByDoctor([FromQuery] GetByDoctorIdRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpGet()]
        [Route("get-patient")]
        public IActionResult GetByPatient([FromQuery] GetByPatientIdRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpPost()]
        [Route("register")]
        public IActionResult Register([FromBody] RegisterMedicalAppointmentRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpPut()]
        [Route("update")]
        public IActionResult Update([FromBody] UpdateMedicalAppointmentRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }
    }

}