using e_Hospital.Application.UseCases.Admin.Command;
using e_Hospital.Application.UseCases.Admin.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HospitalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHospitalCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateHospitalCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var hospital = await _mediator.Send(new GetHospitalByIdQuery { Id = id });

            return Ok(hospital);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var hospitals = await _mediator.Send(new GetAllHospitalQuery());

            if (hospitals.Count == 0)
            {
                return Ok("");
            }

            return Ok(hospitals);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _mediator.Send(new DeleteHospitalCommand() { Id = id });

            return Ok();
        }
    }
}
