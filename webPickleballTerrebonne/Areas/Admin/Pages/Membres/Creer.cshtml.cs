using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webPickleballTerrebonne.Data.Depot;
using webPickleballTerrebonne.Data.Entites;
using webPickleballTerrebonne.ObjetTransfertDonnee.Membre;

namespace webPickleballTerrebonne.Areas.Admin.Pages.Membres
{
    public class CreerModel(IMembreData gestMembres) : PageModel
    {
        private readonly IMembreData _gestMembre = gestMembres;
  
        [BindProperty]
        public MembrePourCreerOtd MembreOtd { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Membre membreDb = MembreOtd.Adapt<Membre>();
                await _gestMembre.CreerMembreAsync(membreDb);
            }
            return RedirectToPage("Index");
        }
    }
}
