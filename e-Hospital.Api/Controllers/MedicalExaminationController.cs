using e_Hospital.Application.UseCases.Admin.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalExaminationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MedicalExaminationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Create(CreateMedicalExaminationResultCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
