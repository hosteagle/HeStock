using HeStock.Application.Repositories.Endpoint;
using MediatR;
using System.Net;

namespace HeStock.Application.Features.Commands.Endpoint.CreateEndpoint
{
    public class CreateEndpointCommandHandler : IRequestHandler<CreateEndpointCommandRequest, CreateEndpointCommandResponse>
    {
        private readonly IEndpointReadRepository _pageReadRepository;
        private readonly IEndpointWriteRepository _pageWriteRepository;

        public CreateEndpointCommandHandler(IEndpointReadRepository pageReadRepository, IEndpointWriteRepository pageWriteRepository)
        {
            _pageReadRepository = pageReadRepository;
            _pageWriteRepository = pageWriteRepository;
        }

        public async Task<CreateEndpointCommandResponse> Handle(CreateEndpointCommandRequest request, CancellationToken cancellationToken)
        {
            var isTherePageRecord = await _pageReadRepository.GetSingleAsync(p => p.pageName ==  request.Name );

            if (isTherePageRecord != null)
                return new CreateEndpointCommandResponse { Message = "Page is already exist", StatusCode = HttpStatusCode.Conflict };

            var addedPage = new Domain.Entities.Endpoint
            {
                pageName = request.Name,
                Description = request.Description,
            };

            await _pageWriteRepository.AddAsync(addedPage);
            int status = await _pageWriteRepository.SaveAsync();

            if (status == 1)
                return new CreateEndpointCommandResponse { Message = "Page added successfully", StatusCode = HttpStatusCode.OK };

            return new CreateEndpointCommandResponse { Message = "Failed to add page. Please try again.", StatusCode = HttpStatusCode.BadGateway };
        }
    }
}
