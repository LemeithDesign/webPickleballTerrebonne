using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webPickleballTerrebonne.Data.Depot;
using webPickleballTerrebonne.Data.Entites;
using webPickleballTerrebonne.ObjetTransfertDonnee.Membre;

namespace webPickleballTerrebonne.Areas.Admin.Pages.Membres
{
    public class IndexModel(IMembreData gestMembres) : PageModel
    {
        private readonly IMembreData _gestMembres = gestMembres;

        public List<MembrePourIndexOtd> MembresOtd { get; set; } = [];

        public async Task OnGetAsync()
        {
            List<Membre> lsMembresDb = await _gestMembres.ObtenirMembresAsync();
            MembresOtd = lsMembresDb.Adapt<List<MembrePourIndexOtd>>();
        }
    }
}
