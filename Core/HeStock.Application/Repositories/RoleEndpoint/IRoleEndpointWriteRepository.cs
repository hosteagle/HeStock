using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeStock.Application.Repositories;

namespace HeStock.Application.Repositories.RoleEndpoint
{
    public interface IRoleEndpointWriteRepository : IWriteRepository<Domain.Entities.RoleEndpoint>
    {
    }
}
