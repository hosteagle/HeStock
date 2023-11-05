using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Commands.Endpoint.DeleteEndpoint
{
    public class DeleteEndpointCommandRequest : IRequest<DeleteEndpointCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
