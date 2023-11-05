using HeStock.Application.Features.Commands.AppRole.CreateRole;
using HeStock.Application.Features.Commands.AppRole.GetAllRoles;
using HeStock.Application.Features.Commands.AppUser.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeStock.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseApiController
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleCommandRequest createUserCommandRequest)
        {
            CreateRoleCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles(GetAllRolesCommandRequest getAllRolesCommandRequest)
        {
            GetAllRolesCommandResponse response = await _mediator.Send(getAllRolesCommandRequest);
            return Ok(response);
        }
    }
}
