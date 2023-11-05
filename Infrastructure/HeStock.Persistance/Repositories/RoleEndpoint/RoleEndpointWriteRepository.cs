using HeStock.Application.Repositories.RoleEndpoint;
using HeStock.Persistance.Contexts;
using HeStock.Persistance.Repositories;

namespace HeStock.Persistance.Repositories.RoleEndpoint
{
    public class RoleEndpointWriteRepository : WriteRepository<Domain.Entities.RoleEndpoint>, IRoleEndpointWriteRepository
    {
        public RoleEndpointWriteRepository(HeStockDbContext context) : base(context)
        {
        }
    }
}
