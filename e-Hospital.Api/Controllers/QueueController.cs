using e_Hospital.Application.UseCases.Users.Commands;
using e_Hospital.Application.UseCases.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QueueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Handle (CreateQueueForPatientCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Handle (GetAllMyQueusQuery query)
        {
            await _mediator.Send(query);
            return Ok();
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Handle (UpdateQueueForPatientCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Handle (DeleteQueueForPatientCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
