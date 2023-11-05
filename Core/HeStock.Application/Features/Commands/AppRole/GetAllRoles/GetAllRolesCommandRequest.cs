using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Commands.AppRole.GetAllRoles
{
    public class GetAllRolesCommandRequest : IRequest<GetAllRolesCommandResponse>
    {
        public string UserId{ get; set; }
    }
}
