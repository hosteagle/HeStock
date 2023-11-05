using HeStock.Application.Features.Commands.Endpoint.DeleteEndpoint;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Validations.Endpoint.DeleteEndpoint
{
    public class DeleteEndpointCommandRequestValidator : AbstractValidator<DeleteEndpointCommandRequest>
    {
        public DeleteEndpointCommandRequestValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty().WithMessage("Id cannot be empty.")
                .NotEqual(Guid.Empty).WithMessage("Please specify a valid Id.");
        }
    }
}
