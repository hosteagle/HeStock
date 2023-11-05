using HeStock.Application.Repositories.Endpoint;
using MediatR;
using System.Net;

namespace HeStock.Application.Features.Commands.Endpoint.DeleteEndpoint
{
    public class DeleteEndpointCommandHandler : IRequestHandler<DeleteEndpointCommandRequest, DeleteEndpointCommandResponse>
    {
        private readonly IEndpointReadRepository _pageReadRepository;
        private readonly IEndpointWriteRepository _pageWriteRepository;

        public DeleteEndpointCommandHandler(IEndpointReadRepository pageReadRepository, IEndpointWriteRepository pageWriteRepository)
        {
            _pageReadRepository = pageReadRepository;
            _pageWriteRepository = pageWriteRepository;
        }

        public async Task<DeleteEndpointCommandResponse> Handle(DeleteEndpointCommandRequest request, CancellationToken cancellationToken)
        {

            var isTherePageRecord = await _pageReadRepository.GetSingleAsync(p => p.Id  == request.Id);

            if (isTherePageRecord == null)
                return new DeleteEndpointCommandResponse { Message = "Page is not found", StatusCode = HttpStatusCode.NotFound };

            isTherePageRecord.IsDeleted = true;
            _pageWriteRepository.Update(isTherePageRecord);
            await _pageWriteRepository.SaveAsync();

            return new DeleteEndpointCommandResponse { Message = $"{isTherePageRecord.pageName} is deleted successfully", StatusCode = HttpStatusCode.OK };
        }
    }
}
