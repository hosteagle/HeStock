using HeStock.Application.Abstractions.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeStock.Infrastructure.Services.Token;

namespace HeStock.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
           
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
           
        }
       
      
    }
}
