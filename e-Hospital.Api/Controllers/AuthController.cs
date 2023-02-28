using e_Hospital.Application.UseCases.Auth.Command;
using e_Hospital.Application.UserCases.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace e_Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Patient/Register")]
        public async Task<IActionResult> UserRegister(PatientRegisterCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> UserLogin(LoginCommand command)
        {
            var token = await _mediator.Send(command);
            return Ok(token);
        }
    }
}
