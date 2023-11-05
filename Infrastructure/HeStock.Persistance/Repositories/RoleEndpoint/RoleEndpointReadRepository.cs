using HeStock.Application.Repositories.RoleEndpoint;
using HeStock.Domain.Entities;
using HeStock.Domain.Entities.Common.Enums.AuthenticationEnums;
using HeStock.Persistance.Contexts;
using HeStock.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HeStock.Persistance.Repositories.RoleEndpoint
{
    public class RoleEndpointReadRepository : ReadRepository<Domain.Entities.RoleEndpoint>, IRoleEndpointReadRepository
    {
        public RoleEndpointReadRepository(HeStockDbContext context) : base(context)
        {
        }

        public Task<bool> CheckRolesEndpointAndOperationType(List<string> roleIds, OperationType operationType, Guid endpointId)
        {
            bool result = false;
            List<Domain.Entities.RoleEndpoint> list = new();
            switch (operationType)
            {
                case OperationType.Create:
                    list = GetWhere(x => roleIds.Contains(x.AppRoleId.ToString()) && x.Create == true && x.EndpointId == endpointId).ToList();
                    break;
                case OperationType.Update:
                    list = GetWhere(x => roleIds.Contains(x.AppRoleId.ToString()) && x.Update == true && x.EndpointId == endpointId).ToList();
                    break;
                case OperationType.Delete:
                    list = GetWhere(x => roleIds.Contains(x.AppRoleId.ToString()) && x.Delete == true && x.EndpointId == endpointId).ToList();
                    break;
                case OperationType.Display:
                    list = GetWhere(x => roleIds.Contains(x.AppRoleId.ToString()) && x.Display == true && x.EndpointId == endpointId).ToList();
                    break;
            }

            if (list.Count() > 0)
                result = true;

            return Task.FromResult(result);
        }
    }
}
