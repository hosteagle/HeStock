using HeStock.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Queries.RoleEndpoint.GetRoleEndpoints
{
    public class GetRoleEndpointsQueryResponse : BaseResponse
    {
        public IEnumerable<Domain.Entities.RoleEndpoint> RoleEndpoints { get; set; }
    }
}
