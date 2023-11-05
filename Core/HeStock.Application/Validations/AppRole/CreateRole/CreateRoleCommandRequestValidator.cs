using HeStock.Application.Features.Commands.AppRole.CreateRole;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Validations.AppRole.CreateRole
{
    public class CreateRoleCommandRequestValidator : AbstractValidator<CreateRoleCommandRequest>
    {
        public CreateRoleCommandRequestValidator()
        {
            RuleFor(request => request.Name)
               .NotEmpty().WithMessage("Name cannot be empty.");
        }
    }
}
