using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webPickleballTerrebonne.Data.Depot;
using webPickleballTerrebonne.Data.Entites;
using webPickleballTerrebonne.ObjetTransfertDonnee.Membre;

namespace webPickleballTerrebonne.Areas.Admin.Pages.Membres
{
    public class DetailsModel(IMembreData gestMembres) : PageModel
    {
        private readonly IMembreData _gestMembres = gestMembres;

        [BindProperty(SupportsGet = true)]
        public int idMembre { get; set; }

        public MembrePourDetailsOtd MembreOtd { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            Membre? membreDb = await _gestMembres.ObtenirMembreParIdAsync(idMembre);
            if (membreDb is null)
                return RedirectToPage("/membres/index");
            MembreOtd = membreDb.Adapt<MembrePourDetailsOtd>();
            return Page();
        }
    }
}
