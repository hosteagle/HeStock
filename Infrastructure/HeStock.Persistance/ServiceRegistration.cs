using HeStock.Application.Abstractions.Services.Authentications;
using HeStock.Application.Abstractions.Services;
using HeStock.Application.Repositories.RoleEndpoint;
using HeStock.Domain.Entities.Identity;
using HeStock.Persistance.Contexts;
using HeStock.Persistance.Repositories.RoleEndpoint;
using HeStock.Persistance.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using HeStock.Application.Repositories.Endpoint;
using HeStock.Persistance.Repositories.Endpoint;

namespace HeStock.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<HeStockDbContext>(opt => opt.UseNpgsql(Configuration.ConnectionString)) ;
            services.AddTransient<IEndpointReadRepository, EndpointReadRepository>();
            services.AddTransient<IEndpointWriteRepository, EndpointWriteRepository>();

            services.AddTransient<IRoleEndpointReadRepository, RoleEndpointReadRepository>();
            services.AddTransient<IRoleEndpointWriteRepository, RoleEndpointWriteRepository>();
            

            services.AddHttpContextAccessor();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISharedIdentityService, SharedIdentityService>();
            services.AddScoped<IEndpointService, EndpointService>();
            services.AddScoped<IRoleEndpointService, RoleEndpointService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthentication, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = false;
                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<HeStockDbContext>()
            .AddDefaultTokenProviders();
            



        }
    }
}
