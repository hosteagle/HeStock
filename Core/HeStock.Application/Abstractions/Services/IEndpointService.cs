﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Abstractions.Services
{
    public interface IEndpointService
    {
        Task<Guid> GetEndpointId(string pageName);
    }
}
