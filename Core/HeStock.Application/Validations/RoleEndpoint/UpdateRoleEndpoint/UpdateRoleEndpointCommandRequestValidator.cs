using HeStock.Application.Features.Commands.RoleEndpoint.UpdateRoleEndpoint;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Validations.RoleEndpoint.UpdateRoleEndpoint
{
    public class UpdateRoleEndpointCommandRequestValidator : AbstractValidator<UpdateRoleEndpointCommandRequest>
    {
        public UpdateRoleEndpointCommandRequestValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty().WithMessage("Id cannot be empty.");

           
            RuleFor(request => request.RoleId)
                .NotEmpty().WithMessage("RoleId cannot be empty.");

            RuleFor(request => request.EndpointId)
                .NotEmpty().WithMessage("PageId cannot be empty.");

            RuleFor(request => request.Create)
                .NotNull().WithMessage("Create cannot be null.")
                .When(request => !request.Update && !request.Delete && !request.Display)
                .WithMessage("At least one permission type must be selected.");

            RuleFor(request => request.Update)
                .NotNull().WithMessage("Update cannot be null.")
                .When(request => !request.Create && !request.Delete && !request.Display)
                .WithMessage("At least one permission type must be selected.");

            RuleFor(request => request.Delete)
                .NotNull().WithMessage("Delete cannot be null.")
                .When(request => !request.Create && !request.Update && !request.Display)
                .WithMessage("At least one permission type must be selected.");

            RuleFor(request => request.Display)
                .NotNull().WithMessage("Display cannot be null.")
                .When(request => !request.Create && !request.Update && !request.Delete)
                .WithMessage("At least one permission type must be selected.");
        }
    }
}
