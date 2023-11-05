using HeStock.Application.Abstractions.Services;
using HeStock.Domain.Entities;
using HeStock.Domain.Entities.Common;
using HeStock.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HeStock.Persistance.Contexts
{
    public class HeStockDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        private readonly ISharedIdentityService _sharedIdentityService;
        public HeStockDbContext(DbContextOptions options, ISharedIdentityService sharedIdentityService) : base(options)
        {
            _sharedIdentityService = sharedIdentityService;

        }
        public DbSet<Endpoint> Endpoints { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<RoleEndpoint> RoleEndpoints { get; set; }
        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                var updateUser = string.IsNullOrEmpty(_sharedIdentityService.GetUserEmail)
                        ? (string.IsNullOrEmpty(data.Entity.UpdatedBy) ? _sharedIdentityService.GetUserEmail : data.Entity.UpdatedBy)
                        : _sharedIdentityService.GetUserEmail;
                var createUser = string.IsNullOrEmpty(_sharedIdentityService.GetUserEmail)
                        ? (string.IsNullOrEmpty(data.Entity.CreatedBy) ? _sharedIdentityService.GetUserEmail : data.Entity.CreatedBy)
                        : _sharedIdentityService.GetUserEmail;
                switch (data.State)
                {
                    case EntityState.Modified:
                        data.Entity.UpdatedDate = DateTime.UtcNow;
                        data.Entity.UpdatedBy = updateUser;
                        break;
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.UtcNow;
                        data.Entity.CreatedBy = createUser;
                        break;
                }

            }
            var IdentityUserDatas = ChangeTracker.Entries<AppUser>();
            foreach (var identityUser in IdentityUserDatas)
            {
                var updateUser = string.IsNullOrEmpty(_sharedIdentityService.GetUserEmail)
                        ? (string.IsNullOrEmpty(identityUser.Entity.UpdatedBy) ? _sharedIdentityService.GetUserEmail : identityUser.Entity.UpdatedBy)
                        : _sharedIdentityService.GetUserEmail;
                var createUser = string.IsNullOrEmpty(_sharedIdentityService.GetUserEmail)
                        ? (string.IsNullOrEmpty(identityUser.Entity.CreatedBy) ? _sharedIdentityService.GetUserEmail : identityUser.Entity.CreatedBy)
                        : _sharedIdentityService.GetUserEmail;
                switch (identityUser.State)
                {
                    case EntityState.Modified:
                        identityUser.Entity.UpdatedDate = DateTime.UtcNow;
                        identityUser.Entity.UpdatedBy = updateUser;
                        break;
                    case EntityState.Added:
                        identityUser.Entity.CreatedDate = DateTime.UtcNow;
                        identityUser.Entity.CreatedBy = createUser;
                        break;
                }
            }

            var IdentityRoleDatas = ChangeTracker.Entries<AppRole>();
            foreach (var identityRole in IdentityRoleDatas)
            {
                var updateUser = string.IsNullOrEmpty(_sharedIdentityService.GetUserEmail)
                        ? (string.IsNullOrEmpty(identityRole.Entity.UpdatedBy) ? _sharedIdentityService.GetUserEmail : identityRole.Entity.UpdatedBy)
                        : _sharedIdentityService.GetUserEmail;
                var createUser = string.IsNullOrEmpty(_sharedIdentityService.GetUserEmail)
                        ? (string.IsNullOrEmpty(identityRole.Entity.CreatedBy) ? _sharedIdentityService.GetUserEmail : identityRole.Entity.CreatedBy)
                        : _sharedIdentityService.GetUserEmail;
                switch (identityRole.State)
                {
                    case EntityState.Modified:
                        identityRole.Entity.UpdatedDate = DateTime.UtcNow;
                        identityRole.Entity.UpdatedBy = updateUser;
                        break;
                    case EntityState.Added:
                        identityRole.Entity.CreatedDate = DateTime.UtcNow;
                        identityRole.Entity.CreatedBy = createUser;
                        break;
                }
            }

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


    }
}
