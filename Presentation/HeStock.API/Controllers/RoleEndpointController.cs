
using HeStock.Application.Features.Commands.RoleEndpoint.CreateRoleEndpoint;
using HeStock.Application.Features.Commands.RoleEndpoint.DeleteRoleEndpoint;
using HeStock.Application.Features.Commands.RoleEndpoint.UpdateRoleEndpoint;

using HeStock.Application.Features.Queries.RoleEndpoint.GetRoleEndpointById;
using HeStock.Application.Features.Queries.RoleEndpoint.GetRoleEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeStock.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleEndpointController : BaseApiController
    {
        private readonly IMediator _mediator;

        public RoleEndpointController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetRoleEndpointsQueryRequest());
            return CreateActionResultInstance<GetRoleEndpointsQueryResponse>(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetRoleEndpointByIdQueryRequest { Id = id });
            return CreateActionResultInstance<GetRoleEndpointByIdQueryResponse>(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateRoleEndpointCommandRequest createRoleEndpoint)
        {
            var result = await _mediator.Send(createRoleEndpoint);
            return CreateActionResultInstance<CreateRoleEndpointCommandResponse>(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRoleEndpointCommandRequest updateRoleEndpoint)
        {
            var result = await _mediator.Send(updateRoleEndpoint);
            return CreateActionResultInstance<UpdateRoleEndpointCommandResponse>(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteRoleEndpointCommandRequest deleteRoleEndpoint)
        {
            var result = await _mediator.Send(deleteRoleEndpoint);
            return CreateActionResultInstance<DeleteRoleEndpointCommandResponse>(result);
        }
    }
}
