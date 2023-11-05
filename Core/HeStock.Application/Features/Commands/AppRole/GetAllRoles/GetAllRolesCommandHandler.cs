using HeStock.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Commands.AppRole.GetAllRoles
{
    public class GetAllRolesCommandHandler : IRequestHandler<GetAllRolesCommandRequest, GetAllRolesCommandResponse>
    {
        readonly IRoleService _roleService;
        public GetAllRolesCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<GetAllRolesCommandResponse> Handle(GetAllRolesCommandRequest request, CancellationToken cancellationToken)
        {

            return new GetAllRolesCommandResponse()
            {
                Roles = await _roleService.GetAllRolesByUserID(request.UserId)
            };
        }

            //throw new UserCreateFailedException();
        }
    }

