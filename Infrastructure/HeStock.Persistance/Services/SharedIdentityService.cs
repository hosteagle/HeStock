using HeStock.Application.Abstractions.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Persistance.Services
{
    public class SharedIdentityService : ISharedIdentityService
    {
        private IHttpContextAccessor _contextAccessor;

        public SharedIdentityService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserEmail
        {
            get
            {
                if (_contextAccessor.HttpContext is not null)
                {
                    string authorizationHeader = _contextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
                    if (!string.IsNullOrWhiteSpace(authorizationHeader))
                    {
                        string token = authorizationHeader.Replace("Bearer ", "");
                        JwtSecurityToken jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

                        Claim userEmailClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "userEmail");

                        if (userEmailClaim != null)
                        {
                            return userEmailClaim.Value;
                        }
                    }
                }



                return ""; // Boş veya hatalı durumlarda boş string dönebilirsiniz.
            }
        }
    }
}
