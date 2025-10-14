using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using webPickleballTerrebonne.Data.Depot;
using webPickleballTerrebonne.Data.Entites;

namespace webPickleballTerrebonne.Claims
{
    public class CustomClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, IOptions<IdentityOptions> optionsAccessor, IMembreData gestMembres) : UserClaimsPrincipalFactory<ApplicationUser>(userManager, optionsAccessor)
    {
        private readonly IMembreData _gestMembres = gestMembres;

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            var membre = await _gestMembres.ObtenirMembreParId(user.MembreId);
            if (membre != null)
            {
                user.Membre = membre;
            }

            if (user.Membre != null)
            {
                //identity.AddClaim(new Claim("MembreId", user.Membre.Id.ToString()));
                //identity.AddClaim(new Claim("NomComplet", $"{user.Membre.Prenom} {user.Membre.Nom}"));
                identity.AddClaim(new Claim("Nom", user.Membre.Nom));
                identity.AddClaim(new Claim("Prenom", user.Membre.Prenom));
            }
            return identity;
        }
    }
}