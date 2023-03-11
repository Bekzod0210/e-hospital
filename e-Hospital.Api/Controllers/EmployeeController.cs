using e_Hospital.Application.UseCases.Admin.Command;
using e_Hospital.Application.UseCases.Users.Queries;
using e_Hospital.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Policy = "AdminActions")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [Authorize(Policy = "AdminActions")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateEmployeeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [Authorize(Policy = "AdminActions")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(DeleteEmployeeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get ([FromRoute]GetAllEmployeesQuery query)
        {
            var employees = await _mediator.Send(query);
            if (employees.Count == 0)
            {
                return Ok("");
            }
            return Ok();
        }
        [Authorize]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetEmployeeByIdQuery query)
        {
            await _mediator.Send(query);
            return Ok();
        }

    }
}
