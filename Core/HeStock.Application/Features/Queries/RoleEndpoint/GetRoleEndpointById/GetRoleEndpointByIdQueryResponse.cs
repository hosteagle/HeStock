using HeStock.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Queries.RoleEndpoint.GetRoleEndpointById
{
    public class GetRoleEndpointByIdQueryResponse : BaseResponse
    {
        public Domain.Entities.RoleEndpoint RoleEndpoint { get; set; }
    }

}
