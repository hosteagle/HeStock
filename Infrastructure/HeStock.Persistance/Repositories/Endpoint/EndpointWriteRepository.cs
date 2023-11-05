using HeStock.Application.Repositories.Endpoint;
using HeStock.Domain.Entities;
using HeStock.Persistance.Contexts;
using HeStock.Persistance.Repositories;

namespace HeStock.Persistance.Repositories.Endpoint
{
    public class EndpointWriteRepository : WriteRepository<Domain.Entities.Endpoint>, IEndpointWriteRepository
    {
        public EndpointWriteRepository(HeStockDbContext context) : base(context)
        {
        }
    }
}
