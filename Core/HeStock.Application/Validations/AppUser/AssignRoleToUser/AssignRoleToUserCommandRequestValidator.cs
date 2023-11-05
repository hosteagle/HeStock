using HeStock.Application.Features.Commands.AppUser.AssignRoleToUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Validations.AppUser.AssignRoleToUser
{
    public class AssignRoleToUserCommandRequestValidator : AbstractValidator<AssignRoleToUserCommandRequest>
    {
        public AssignRoleToUserCommandRequestValidator()
        {
            RuleFor(request => request.UserId)
                        .NotEmpty().WithMessage("UserId cannot be empty.");

            RuleFor(request => request.Roles)
                .NotEmpty().WithMessage("Roles cannot be empty.")
                .ForEach(role => role.NotEmpty().WithMessage("A role cannot be empty."));
        }
    }
}
