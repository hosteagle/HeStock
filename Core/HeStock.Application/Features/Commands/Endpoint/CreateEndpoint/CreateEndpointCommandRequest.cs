using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Commands.Endpoint.CreateEndpoint
{
    public class CreateEndpointCommandRequest : IRequest<CreateEndpointCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
