using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Commands.RoleEndpoint.CreateRoleEndpoint
{
    public class CreateRoleEndpointCommandRequest : IRequest<CreateRoleEndpointCommandResponse>
    {
        public Guid RoleId { get; set; }
        public Guid EndpointId { get; set; }
        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Display { get; set; }
    }
}
