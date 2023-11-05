using HeStock.Application.Features.Commands.RoleEndpoint.DeleteRoleEndpoint;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Commands.RoleEndpoint.DeleteRoleEndpoint
{
    public class DeleteRoleEndpointCommandRequest : IRequest<DeleteRoleEndpointCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
