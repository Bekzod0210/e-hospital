using e_Hospital.Application.UseCases.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinieCartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicinieCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToCart(AddMedicineToCartCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFromCart([FromRoute] int id)
        {
            await _mediator.Send(new RemoveOneMedicineFromCartCommand { PharmacyMedicineId = id });
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAllFromCart(RemoveAllMedicinesFromCartCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
