using HeStock.Application.Behaviors;
using HeStock.Domain.Entities.Common.Enums.AuthenticationEnums;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {

            collection.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            collection.AddHttpClient();
            collection.AddAutoMapper(Assembly.GetExecutingAssembly());
            collection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            collection.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(ExceptionHandlingBehavior<,,>));
            collection.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        }
    }
}
