using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using webPickleballTerrebonne.Data.Depot;
using webPickleballTerrebonne.Data.Entites;

namespace webPickleballTerrebonne.Services
{
    public interface IMembreService
    {
        Task<Membre?> ObtenirMembrePourAppUserAsync(ClaimsPrincipal cp);
    }
    public class MembreService(UserManager<ApplicationUser> userManager, IMembreData gestMembres) : IMembreService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IMembreData _gestMembres = gestMembres;

        public async Task<Membre?> ObtenirMembrePourAppUserAsync(ClaimsPrincipal cp)
        {
            var user = await _userManager.GetUserAsync(cp);
            if (user == null) return null;

            if (user?.Membre == null)
            {
                Membre? m = await _gestMembres.ObtenirMembreParId(user.MembreId);
                if (m != null)
                {
                    user.Membre = m;
                    return user.Membre;
                }
            }
            return null;
        }
    }
}
