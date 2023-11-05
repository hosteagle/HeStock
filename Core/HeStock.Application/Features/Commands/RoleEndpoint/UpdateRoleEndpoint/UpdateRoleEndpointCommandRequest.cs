using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Commands.RoleEndpoint.UpdateRoleEndpoint
{
    public class UpdateRoleEndpointCommandRequest : IRequest<UpdateRoleEndpointCommandResponse>
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid EndpointId { get; set; }
        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Display { get; set; }
    }
}
