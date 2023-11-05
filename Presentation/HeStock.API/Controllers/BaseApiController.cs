using HeStock.Application.Features.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HeStock.API.Controllers
{
 
    public class BaseApiController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(BaseResponse response) where T : BaseResponse
        {
            return new ObjectResult(response)
            {
                StatusCode = (int?)response.StatusCode,
            };
        }
    }
}
