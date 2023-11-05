using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Commands.Auth.Login
{
    public class LoginCommandResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
