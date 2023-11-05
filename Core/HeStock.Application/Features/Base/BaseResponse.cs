using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Features.Base
{
    public class BaseResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
