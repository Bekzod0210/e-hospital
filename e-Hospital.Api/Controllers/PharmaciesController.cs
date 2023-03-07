using e_Hospital.Application.UseCases.Admin.Command;
using e_Hospital.Application.UseCases.Admin.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaciesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PharmaciesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePharmacyCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePharmacyCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var pharmacy = await _mediator.Send(new GetPharmacyByIdQuery { Id = id });

            return Ok(pharmacy);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var pharmacies = await _mediator.Send(new GetAllPharmacyQuery());

            if (pharmacies.Count == 0)
            {
                return Ok("");
            }

            return Ok(pharmacies);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _mediator.Send(new DeletePharmacyCommand() { Id = id });

            return Ok();
        }
    }
}
