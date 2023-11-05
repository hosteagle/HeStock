using HeStock.Application.Repositories.Endpoint;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Queries.Endpoint.GetPageById
{
    public class GetEndpointByIdQueryHandler : IRequestHandler<GetEndpointByIdQueryRequest, GetEndpointByIdQueryResponse>
    {
        private readonly IEndpointReadRepository _pageReadRepository;

        public GetEndpointByIdQueryHandler(IEndpointReadRepository pageReadRepository)
        {
            _pageReadRepository = pageReadRepository;
        }

        public async Task<GetEndpointByIdQueryResponse> Handle(GetEndpointByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _pageReadRepository.GetSingleAsync(d => d.Id == request.Id);
            if (data == null) return new GetEndpointByIdQueryResponse { Message = "Endpoint is not exist.", StatusCode = HttpStatusCode.NotFound };
            return new GetEndpointByIdQueryResponse { Endpoint=data,StatusCode=HttpStatusCode.OK};
        }
    }
}
