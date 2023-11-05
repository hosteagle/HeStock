using HeStock.Application.Abstractions.Services;
using HeStock.Application.Repositories.Endpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Persistance.Services
{
    public class EndpointService : IEndpointService
    {
        private readonly IEndpointReadRepository _endpointReadRepository;

        public EndpointService(IEndpointReadRepository endpointReadRepository)
        {
            _endpointReadRepository = endpointReadRepository;
        }

        public async Task<Guid> GetEndpointId(string endpointName)
        {
            var page = await _endpointReadRepository.GetSingleAsync(x => x.pageName == endpointName);
            return page.Id;
        }


    }
}
