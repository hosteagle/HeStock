using HeStock.Application.Features.Commands.Endpoint.CreateEndpoint;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Validations.Endpoint.CreateEndpoint
{
    public class CreateEndpointCommandRequestValidator : AbstractValidator<CreateEndpointCommandRequest>
    {
        public CreateEndpointCommandRequestValidator()
        {

            RuleFor(request => request.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(50).WithMessage("Name must be maximum 50 characters long.");
        }
    }
}
