using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Commands.Auth.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
       public string usernameOrEmail { get; set; }
       public string password { get; set; }
    }
}
