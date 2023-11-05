using HeStock.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Commands.AppRole.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
    {
        readonly IRoleService _roleService;
        public CreateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _roleService.CreateRole(request.Name);

            return new CreateRoleCommandResponse()
            {

                Succeeded = response
            };

            //throw new UserCreateFailedException();
        }
    }
}
