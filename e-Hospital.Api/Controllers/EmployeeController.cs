using e_Hospital.Application.UseCases.Admin.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace e_Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]

        public async Task<IActionResult> Create (CreateEmployeeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
