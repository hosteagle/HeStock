using HeStock.Application.Repositories.RoleEndpoint;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Queries.RoleEndpoint.GetRoleEndpoints
{
    public class GetRoleEndpointsQueryHandler : IRequestHandler<GetRoleEndpointsQueryRequest, GetRoleEndpointsQueryResponse>
    {
        private readonly IRoleEndpointReadRepository _RoleEndpointReadRepository;

        public GetRoleEndpointsQueryHandler(IRoleEndpointReadRepository RoleEndpointReadRepository)
        {
            _RoleEndpointReadRepository = RoleEndpointReadRepository;
        }

        public async Task<GetRoleEndpointsQueryResponse> Handle(GetRoleEndpointsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _RoleEndpointReadRepository.GetAllAsync(p => p.IsDeleted == false);
            return new GetRoleEndpointsQueryResponse { RoleEndpoints = data, StatusCode = HttpStatusCode.OK };
        }
    }
}
