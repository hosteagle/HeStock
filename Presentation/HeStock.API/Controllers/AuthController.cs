using HeStock.Application.Features.Commands.AppRole.CreateRole;
using HeStock.Application.Features.Commands.Auth.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest loginCommandRequest)
        {
            LoginCommandResponse response = await _mediator.Send(loginCommandRequest);
            return Ok(response);
        }

    }
}
