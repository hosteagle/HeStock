using HeStock.Application.Features.Commands.RoleEndpoint.DeleteRoleEndpoint;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Validations.RoleEndpoint.DeleteRoleEndpoint
{
    public class DeleteRoleEndpointCommandRequestValidator : AbstractValidator<DeleteRoleEndpointCommandRequest>
    {
        public DeleteRoleEndpointCommandRequestValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty().WithMessage("Id cannot be empty.")
                .NotEqual(Guid.Empty).WithMessage("Please specify a valid Id.");
        }
    }
}
