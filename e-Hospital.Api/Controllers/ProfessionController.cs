using e_Hospital.Application.UseCases.Admin.Command;
using e_Hospital.Application.UseCases.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var professions = await _mediator.Send(new GetAllProfessionQuery());
            return Ok(professions);
        }

        [HttpPost]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Create(CreateProfessionCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Update(UpdateProfessionCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProfessionCommand() { Id = id });
            return Ok();
        }
    }
}
