using HeStock.Application.Abstractions.Services;
using HeStock.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Persistance.Services
{
    public class RoleService : IRoleService
    {
        readonly RoleManager<AppRole> _roleManager;
        readonly UserManager<AppUser> _userManager;


        public RoleService(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<bool> CreateRole(string name)
        {
            IdentityResult result = await _roleManager.CreateAsync(new() { Id = Guid.NewGuid(), Name = name});

            return result.Succeeded;
        }

        public async Task<bool> DeleteRole(string id)
        {
            AppRole appRole = await _roleManager.FindByIdAsync(id);
            IdentityResult result = await _roleManager.DeleteAsync(appRole);
            return result.Succeeded;
        }

        public async Task<List<string>> GetAllRolesByUserID(string userId)
        {
            AppUser user = _userManager.Users.Where(x => x.Id == Guid.Parse(userId)).FirstOrDefault();
            List<string> roles = (List<string>)await _userManager.GetRolesAsync(user);


            return roles;
        }

        public async Task<List<string>> GetAllRolesIDByUserID(string userId)
        {

            List<string> roleNames = await GetAllRolesByUserID(userId);
            List<string> roleIds = await _roleManager.Roles
                .Where(x => roleNames.AsEnumerable().Contains(x.Name))
                .Select(r => r.Id.ToString()).ToListAsync();
            return roleIds;
        }

        public async Task<(string id, string name)> GetRoleById(string id)
        {
            string role = await _roleManager.GetRoleIdAsync(new() { Id = Guid.Parse(id) });
            return (id, role);
        }

        public async Task<bool> UpdateRole(string id, string name)
        {
            AppRole role = await _roleManager.FindByIdAsync(id);
            role.Name = name;
            IdentityResult result = await _roleManager.UpdateAsync(role);
            return result.Succeeded;
        }
    }
}
