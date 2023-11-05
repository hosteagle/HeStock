using HeStock.Application.Abstractions.Services;
using HeStock.Application.Repositories.RoleEndpoint;
using HeStock.Domain.Entities.Common.Enums.AuthenticationEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Persistance.Services
{
    public class RoleEndpointService : IRoleEndpointService
    {
        readonly IRoleEndpointReadRepository _RoleEndpointReadRepository;

        public RoleEndpointService(IRoleEndpointReadRepository RoleEndpointReadRepository)
        {
            _RoleEndpointReadRepository = RoleEndpointReadRepository;
        }


        public async Task<bool> CheckRolesPageAndOperationType(List<string> roleIds, OperationType operationType, Guid pageId)
        {
            return await _RoleEndpointReadRepository.CheckRolesEndpointAndOperationType(roleIds, operationType,pageId);
        }
    }
}
