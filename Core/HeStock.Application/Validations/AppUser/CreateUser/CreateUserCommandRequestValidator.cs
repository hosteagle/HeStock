using HeStock.Application.Features.Commands.AppUser.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Validations.AppUser.CreateUser
{
    public class CreateUserCommandRequestValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserCommandRequestValidator()
        {
            RuleFor(request => request.NameSurname)
                .NotEmpty().WithMessage("Name and surname cannot be empty.");

            RuleFor(request => request.Username)
                .NotEmpty().WithMessage("Username cannot be empty.");

            RuleFor(request => request.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(request => request.Password)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain an uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain a lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain a digit.");

            RuleFor(request => request.PasswordConfirm)
                .NotEmpty().WithMessage("Password confirmation cannot be empty.")
                .Equal(request => request.Password).WithMessage("Password confirmation must match the password.");
        }
    }
}
