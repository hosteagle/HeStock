using HeStock.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Queries.Endpoint.GetPages
{
    public class GetEndpointsQueryResponse : BaseResponse
    {
        public IEnumerable<Domain.Entities.Endpoint> Endpoints { get; set; }
    }
}
