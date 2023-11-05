using HeStock.Domain.Entities;
using HeStock.Domain.Entities.Common.Enums.AuthenticationEnums;
using HeStock.Domain.Entities.Identity;
using HeStock.Persistance.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace HeStock.Persistance
{
    public static class SeedData
    {
        //Seed Data for Admin
        public static async Task AddSeedDatasAsync(this IApplicationBuilder app)
        {

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<HeStockDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();


                context.Database.Migrate();


                //if (context.Companies.Count() < 1)
                //{
                    //var adminCompany = new Company() { Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, CreatedBy = "admin@commuvent.com", Name = "Commuvent" };
                    //context.Companies.Add(adminCompany);

                    //var department = new Department() { Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, CompanyId = adminCompany.Id, Name = "CommuventDepartment", CreatedBy = "admin@commuvent.com" };
                    //context.Departments.Add(department);

                    var user = new AppUser()
                    {
                        Id = Guid.NewGuid(),
                        UserName = "Admin",
                        Email = "info@hosteagle.com.tr",
                        NameSurname = "Hestock Admin",
                        EmailConfirmed = true

                    };
                    await userManager.CreateAsync(user, "Hosteagle2023");

                    var role = new AppRole() { Id = Guid.NewGuid(), Name = "HeStock Admin Role", CreatedBy = "info@hosteagle.com.tr" };

                    await roleManager.CreateAsync(role);

                    await userManager.AddToRolesAsync(user, new List<string> { "HeStock Admin Role" });

                    foreach (EndpointNames endpoint in Enum.GetValues(typeof(EndpointNames)))
                    {
                        var newEndpoint = new Endpoint { Id = Guid.NewGuid(), CreatedBy = "info@hosteagle.com.tr", CreatedDate = DateTime.UtcNow, pageName = endpoint.ToString(), Description = $"{endpoint} Access" };
                        var roleEndpoint = new RoleEndpoint { Id = Guid.NewGuid(), CreatedBy = "info@hosteagle.com.tr", CreatedDate = DateTime.UtcNow, AppRoleId = role.Id, EndpointId = newEndpoint.Id, Create = true, Delete = true, Display = true, Update = true };
                        context.Endpoints.Add(newEndpoint);
                        context.RoleEndpoints.Add(roleEndpoint);
                    }
                //}

                // TODO : Burası değişecek endpoint olarak tasarladığımızda


                await context.SaveChangesAsync();


            }

        }
    }
}
