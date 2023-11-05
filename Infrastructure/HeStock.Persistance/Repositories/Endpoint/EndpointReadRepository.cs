using HeStock.Application.Repositories.Endpoint;
using HeStock.Persistance.Contexts;
using HeStock.Persistance.Repositories;

namespace HeStock.Persistance.Repositories.Endpoint
{
    public class EndpointReadRepository : ReadRepository<Domain.Entities.Endpoint>, IEndpointReadRepository
    {
        public EndpointReadRepository(HeStockDbContext context) : base(context)
        {
        }
    }
}
