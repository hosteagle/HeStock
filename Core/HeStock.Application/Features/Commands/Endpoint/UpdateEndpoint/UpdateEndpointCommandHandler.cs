using HeStock.Application.Repositories.Endpoint;
using MediatR;
using System.Net;

namespace HeStock.Application.Features.Commands.Endpoint.UpdateEndpoint
{
    public class UpdateEndpointCommandHandler : IRequestHandler<UpdateEndpointCommandRequest, UpdateEndpointCommandResponse>
    {
        private readonly IEndpointWriteRepository _pageWriteRepository;
        private readonly IEndpointReadRepository _pageReadRepository;

        public UpdateEndpointCommandHandler(IEndpointWriteRepository pageWriteRepository, IEndpointReadRepository pageReadRepository)
        {
            _pageWriteRepository = pageWriteRepository;
            _pageReadRepository = pageReadRepository;
        }

        public async Task<UpdateEndpointCommandResponse> Handle(UpdateEndpointCommandRequest request, CancellationToken cancellationToken)
        {

            var isTherePageRecord = await _pageReadRepository.GetSingleAsync(p => p.Id == request.Id);

            isTherePageRecord.pageName = request.Name;

            _pageWriteRepository.Update(isTherePageRecord);
            _pageWriteRepository.SaveAsync();
            return new UpdateEndpointCommandResponse { StatusCode = HttpStatusCode.OK };
        }
    }
}
