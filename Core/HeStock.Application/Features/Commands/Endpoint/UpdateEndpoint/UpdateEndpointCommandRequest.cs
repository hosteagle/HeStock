using HeStock.Application.Features.Commands.Endpoint.UpdateEndpoint;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Commands.Endpoint.UpdateEndpoint
{
    public class UpdateEndpointCommandRequest : IRequest<UpdateEndpointCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UpdatedBy { get; set; }
    }
}
