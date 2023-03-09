using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_Hospital.Application.UseCases.Admin.Command;
using e_Hospital.Application.UseCases.Admin.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Create(CreateMedicineCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Update(UpdateMedicineCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var medicine = await _mediator.Send(new GetMedicineByIdQuery { Id = id });

            return Ok(medicine);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var medicines = await _mediator.Send(new GetAllMedicineQuery());

            if (medicines.Count == 0)
            {
                return Ok("");
            }

            return Ok(medicines);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _mediator.Send(new DeleteMedicineCommand() { Id = id });

            return Ok();
        }
    }
}

