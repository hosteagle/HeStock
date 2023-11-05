using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeStock.Domain.Entities.Common.Enums.AuthenticationEnums;
using HeStock.Application.Repositories;

namespace HeStock.Application.Repositories.RoleEndpoint
{
    public interface IRoleEndpointReadRepository : IReadRepository<Domain.Entities.RoleEndpoint>
    {
        Task<bool> CheckRolesEndpointAndOperationType(List<string> roleIds, OperationType operationType, Guid endpointId);

    }
}
