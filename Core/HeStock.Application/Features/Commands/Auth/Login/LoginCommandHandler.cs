using HeStock.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Commands.Auth.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        readonly IAuthService _authService;
        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _authService.LoginAsync(request.usernameOrEmail, request.password, 3600);

            return new LoginCommandResponse()
            {
                AccessToken = response.AccessToken,
                RefreshToken = response.RefreshToken,
            };

            //throw new UserCreateFailedException();
        }
    }
}
