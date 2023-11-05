using HeStock.Application.Abstractions.Services;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeStock.Application.Validations.AppUser.AssignRoleToUser;

namespace HeStock.Application.Features.Commands.AppUser.AssignRoleToUser
{
    public class AssignRoleToUserCommandHandler : IRequestHandler<AssignRoleToUserCommandRequest, AssignRoleToUserCommandResponse>
    {
        readonly IUserService _userService;
        readonly AssignRoleToUserCommandRequestValidator _validator;

        public AssignRoleToUserCommandHandler(IUserService userService, AssignRoleToUserCommandRequestValidator validator)
        {
            _userService = userService;
            _validator = validator;
        }

        public async Task<AssignRoleToUserCommandResponse> Handle(AssignRoleToUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _userService.AssignRoleToUserAsnyc(request.UserId, request.Roles);
            return new();
        }
    }

}
