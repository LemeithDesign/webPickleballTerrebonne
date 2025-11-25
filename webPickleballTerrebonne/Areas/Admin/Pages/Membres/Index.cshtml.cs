using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using webPickleballTerrebonne.Data.Constantes;
using webPickleballTerrebonne.Data.Depot;
using webPickleballTerrebonne.Data.Entites;
using webPickleballTerrebonne.ObjetTransfertDonnee.Membre;

namespace webPickleballTerrebonne.Areas.Admin.Pages.Membres
{
    //[Authorize(Policy = NomsStrategiesAuthorisation.Admin)]
    public class IndexModel(IMembreData gestMembres) : PageModel
    {
        private readonly IMembreData _gestMembres = gestMembres;

        public List<MembrePourIndexOtd> MembresOtd { get; set; } = [];

        public string TrierNom { get; set; } = string.Empty;
        public string TrierPrenom { get; set; } = string.Empty;
        public string TrierDate { get; set; } = string.Empty;
        public string CurrentFilter { get; set; } = string.Empty;
        public string CurrentSort { get; set; } = string.Empty;


        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            List<Membre> lsMembresDb = await _gestMembres.ObtenirMembresAsync();
            List<MembrePourIndexOtd> membresOtd = [];
            foreach (var membre in lsMembresDb)
            {
                IList<string> lsRoles = await _gestMembres.ObtenirRolesMembreParIdAsync(membre.Id);
                MembrePourIndexOtd membreOtd = membre.Adapt<MembrePourIndexOtd>();
                membreOtd.Roles = lsRoles;
                membresOtd.Add(membreOtd);
            }
            //List<MembrePourIndexOtd> membresOtd = lsMembresDb.Adapt<List<MembrePourIndexOtd>>();

            TrierNom = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            TrierPrenom = sortOrder == "prenom" ? "prenom_desc" : "prenom";
            TrierDate = sortOrder == "date" ? "date_desc" : "date";
            
            CurrentFilter = searchString;

            IQueryable<MembrePourIndexOtd> membresIQ = membresOtd.AsQueryable();

            if(!string.IsNullOrEmpty(searchString))
            {
                membresIQ = membresIQ.Where(s => s.Nom.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                       || s.Prenom.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            membresIQ = sortOrder switch
            {
                "name_desc" => membresIQ.OrderByDescending(s => s.Nom),
                "prenom" => membresIQ.OrderBy(s => s.Prenom),
                "prenom_desc" => membresIQ.OrderByDescending(s => s.Prenom),
                "date" => membresIQ.OrderBy(s => s.Depuis),
                "date_desc" => membresIQ.OrderByDescending(s => s.Depuis),
                _ => membresIQ.OrderBy(s => s.Nom),
            };

            MembresOtd = [.. membresIQ.AsNoTracking()];
        }
    }
}
