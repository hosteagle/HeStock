using HeStock.Application.Features.Commands.Endpoint.CreateEndpoint;
using HeStock.Application.Features.Commands.Endpoint.DeleteEndpoint;
using HeStock.Application.Features.Commands.Endpoint.UpdateEndpoint;
using HeStock.Application.Features.Queries.Endpoint.GetPageById;
using HeStock.Application.Features.Queries.Endpoint.GetPages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeStock.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EndpointController : BaseApiController
    {
        private readonly IMediator _mediator;

        public EndpointController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetEndpointsQueryRequest());
            return CreateActionResultInstance<GetEndpointsQueryResponse>(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetEndpointByIdQueryRequest { Id = id });
            return CreateActionResultInstance<GetEndpointByIdQueryResponse>(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateEndpointCommandRequest createPage)
        {
            var result = await _mediator.Send(createPage);
            return CreateActionResultInstance<CreateEndpointCommandResponse>(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateEndpointCommandRequest updatePage)
        {
            var result = await _mediator.Send(updatePage);
            return CreateActionResultInstance<UpdateEndpointCommandResponse>(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteEndpointCommandRequest deletePage)
        {
            var result = await _mediator.Send(deletePage);
            return CreateActionResultInstance<DeleteEndpointCommandResponse>(result);
        }
    }
}
