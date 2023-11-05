using HeStock.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Queries.Endpoint.GetPageById
{
    public class GetEndpointByIdQueryResponse : BaseResponse
    {
        public Domain.Entities.Endpoint Endpoint { get; set; }
    }
}
