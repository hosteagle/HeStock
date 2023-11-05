using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Queries.Endpoint.GetPageById
{
    public class GetEndpointByIdQueryRequest : IRequest<GetEndpointByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
