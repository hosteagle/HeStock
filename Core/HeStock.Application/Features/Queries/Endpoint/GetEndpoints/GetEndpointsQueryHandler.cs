using HeStock.Application.Repositories.Endpoint;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Queries.Endpoint.GetPages
{
    public class GetEndpointsQueryHandler : IRequestHandler<GetEndpointsQueryRequest, GetEndpointsQueryResponse>
    {
        private readonly IEndpointReadRepository _pageReadRepository;

        public GetEndpointsQueryHandler(IEndpointReadRepository pageReadRepository)
        {
            _pageReadRepository = pageReadRepository;
        }

        public async Task<GetEndpointsQueryResponse> Handle(GetEndpointsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _pageReadRepository.GetAllAsync(p => p.IsDeleted == false);

            return new GetEndpointsQueryResponse { Endpoints = data, StatusCode=HttpStatusCode.OK};
        }
    }
}
