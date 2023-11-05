using HeStock.Domain.Entities.Common.Enums.AuthenticationEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Abstractions.Services
{
    public interface IRoleEndpointService
    {
        Task<bool> CheckRolesPageAndOperationType(List<string> roleIds, OperationType operationType, Guid pageId);
    }
}
