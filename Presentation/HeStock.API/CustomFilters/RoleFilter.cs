using HeStock.Application.Abstractions.Services;
using HeStock.Application.CustomAttributes;
using HeStock.Application.Repositories.RoleEndpoint;
using HeStock.Domain.Entities.Common.Enums.AuthenticationEnums;
using HeStock.Persistance.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace HeStock.API.CustomFilters
{
    public class RoleFilter : IAsyncActionFilter
    {

        private readonly IRoleService _roleService;
        private readonly IRoleEndpointService _RoleEndpointService;
        private readonly IEndpointService _endpointService;

        public RoleFilter(IRoleService roleService, IRoleEndpointService RoleEndpointService, IEndpointService endpointService)
        {
            _roleService = roleService;
            _RoleEndpointService = RoleEndpointService;
            _endpointService = endpointService;
        }



        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string token = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            ControllerActionDescriptor controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            AuthorizeDefinitionAttribute attribute = controllerActionDescriptor.MethodInfo.GetCustomAttribute(typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;

            if (!string.IsNullOrEmpty(token) && attribute is not null) // If token and attribute is exist
            {
                var result = false;

                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                var userId = jwt.Claims.FirstOrDefault(x => x.Type == "userID").Value;

                //Role Checking Services 
                Guid endpointId = await _endpointService.GetEndpointId(controllerActionDescriptor.ControllerName);

                var userRoles = await _roleService.GetAllRolesIDByUserID(userId);
                result = await _RoleEndpointService.CheckRolesPageAndOperationType(userRoles, attribute.OperationType, endpointId);


                if (!result)
                    context.Result = new UnauthorizedResult();
                else
                    await next();
            }
            else if (attribute is not null) // If only attribute is exist
            {
                context.Result = new UnauthorizedResult();
            }
            else // For open access
            {
                await next();
            }


        }
    }
}
