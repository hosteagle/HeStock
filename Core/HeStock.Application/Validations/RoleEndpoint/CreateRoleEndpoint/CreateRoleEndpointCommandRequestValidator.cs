using HeStock.Application.Features.Commands.RoleEndpoint.CreateRoleEndpoint;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Validations.RoleEndpoint.CreateRoleEndpoint
{
    public class CreateRoleEndpointCommandRequestValidator : AbstractValidator<CreateRoleEndpointCommandRequest>
    {
        public CreateRoleEndpointCommandRequestValidator()
        {


            RuleFor(request => request.RoleId)
                .NotEmpty().WithMessage("Role ID cannot be empty.");

            RuleFor(request => request.EndpointId)
                .NotEmpty().WithMessage("Page ID cannot be empty.");

            RuleFor(request => request.Create)
                .Equal(true).When(request => request.Update || request.Delete || request.Display)
                .WithMessage("If create permission is granted, other permissions must be disabled.");

            RuleFor(request => request.Update)
                .Equal(true).When(request => request.Create || request.Delete || request.Display)
                .WithMessage("If update permission is granted, other permissions must be disabled.");

            RuleFor(request => request.Delete)
                .Equal(true).When(request => request.Create || request.Update || request.Display)
                .WithMessage("If delete permission is granted, other permissions must be disabled.");

            RuleFor(request => request.Display)
                .Equal(true).When(request => request.Create || request.Update || request.Delete)
                .WithMessage("If display permission is granted, other permissions must be disabled.");
        }
    }
}
