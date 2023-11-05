using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Application.Abstractions.Services
{
    public interface IRoleService
    {
        Task<List<string>> GetAllRolesByUserID(string userId);
        Task<List<string>> GetAllRolesIDByUserID(string userId);
        Task<(string id, string name)> GetRoleById(string id);
        Task<bool> CreateRole(string name);
        Task<bool> DeleteRole(string id);
        Task<bool> UpdateRole(string id, string name);
    }
}
