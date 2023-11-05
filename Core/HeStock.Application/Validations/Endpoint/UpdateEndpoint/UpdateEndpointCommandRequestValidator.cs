using HeStock.Application.Features.Commands.Endpoint.UpdateEndpoint;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Validations.Endpoint.UpdateEndpoint
{
    public class UpdateEndpointCommandRequestValidator : AbstractValidator<UpdateEndpointCommandRequest>
    {
        public UpdateEndpointCommandRequestValidator()
        {
            RuleFor(request => request.Id).NotEmpty().WithMessage("Id cannot be empty.");
            RuleFor(request => request.Name).NotEmpty().WithMessage("Name cannot be empty.");
            RuleFor(request => request.UpdatedBy).NotEmpty().WithMessage("Updater cannot be empty.");
        }
    }
}
