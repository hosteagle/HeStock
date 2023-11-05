using HeStock.Application.Repositories.RoleEndpoint;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Queries.RoleEndpoint.GetRoleEndpointById
{
    public class GetRoleEndpointByIdQueryHandler : IRequestHandler<GetRoleEndpointByIdQueryRequest, GetRoleEndpointByIdQueryResponse>
    {
        private readonly IRoleEndpointReadRepository _RoleEndpointReadRepository;

        public GetRoleEndpointByIdQueryHandler(IRoleEndpointReadRepository RoleEndpointReadRepository)
        {
            _RoleEndpointReadRepository = RoleEndpointReadRepository;
        }

        public async Task<GetRoleEndpointByIdQueryResponse> Handle(GetRoleEndpointByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _RoleEndpointReadRepository.GetSingleAsync(rp => rp.Id == request.Id);

            if (data == null) return new GetRoleEndpointByIdQueryResponse { Message = "Role page does not exist.", StatusCode = HttpStatusCode.NotFound };
            return new GetRoleEndpointByIdQueryResponse { RoleEndpoint = data, StatusCode = HttpStatusCode.OK };
        }
    }
}
