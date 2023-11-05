using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Queries.RoleEndpoint.GetRoleEndpointById
{
    public class GetRoleEndpointByIdQueryRequest : IRequest<GetRoleEndpointByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
