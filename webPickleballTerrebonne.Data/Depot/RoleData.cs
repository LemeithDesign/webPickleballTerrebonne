using Microsoft.AspNetCore.Identity;

namespace webPickleballTerrebonne.Data.Depot
{

    public interface IRoleData
    {
        Task InitialiserRolesAsync(string nomRole);
    }

    public class RoleData(RoleManager<IdentityRole> roleManager) : IRoleData
    {
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;

        public async Task InitialiserRolesAsync(string nomRole)
        {
            if (await _roleManager.RoleExistsAsync(nomRole) == false)
            {
                await _roleManager.CreateAsync(new IdentityRole(nomRole));
            }
        }
    }
}