using Microsoft.AspNetCore.Identity;

namespace webPickleballTerrebonne.Services
{
    public class RoleService(IServiceProvider serviceProvider) : IHostedService
    {

        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new List<string>
            {
                Data.Constantes.NomsRoles.Admin,
                Data.Constantes.NomsRoles.CA,
                Data.Constantes.NomsRoles.Membre,
                Data.Constantes.NomsRoles.User
            };

            foreach (var roleName in roles)
            {
                var roleExists = roleManager.RoleExistsAsync(roleName).Result;
                if (!roleExists)
                {
                    var role = new IdentityRole(roleName);
                    var result = roleManager.CreateAsync(role).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception($"Erreur lors de la création du rôle '{roleName}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }
                }
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
