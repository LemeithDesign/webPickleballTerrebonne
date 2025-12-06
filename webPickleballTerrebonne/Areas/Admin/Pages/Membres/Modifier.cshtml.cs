using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webPickleballTerrebonne.Data.Depot;
using webPickleballTerrebonne.Data.Entites;
using webPickleballTerrebonne.ObjetTransfertDonnee.Membre;

namespace webPickleballTerrebonne.Areas.Admin.Pages.Membres
{
    public class ModifierModel(IMembreData gestMembres) : PageModel
    {
        private readonly IMembreData _gestMembres = gestMembres;

        [BindProperty(SupportsGet = true)]
        public int idMembre { get; set; }

        [BindProperty]
        public MembrePourModifierOtd MembreOtd { get; set; } = default!;

        public IActionResult OnGet()
        {
            return NotFound();
        }

        //public async Task<IActionResult> OnGetAsync()
        //{
        //    Membre? membreDb = await _gestMembres.ObtenirMembreParIdAsync(idMembre);
        //    if (membreDb is null)
        //        return RedirectToPage("/membres/index");
        //    MembreOtd = membreDb.Adapt<MembrePourModifierOtd>();
        //    return Page();
        //}
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Membre? membreDb = await _gestMembres.ObtenirMembreParIdAsync(idMembre);
        //        if (membreDb is null)
        //            return RedirectToPage("/membres/index");
        //        bool dbChangee = ValiderMembre(membreDb);

        //        if (dbChangee)
        //        {
        //            await _gestMembres.ModifierMembreAsync(membreDb);
        //        }
        //    }
        //    return RedirectToPage("/membres/index");
        //}

        //private bool ValiderMembre(Membre membreDb)
        //{
        //    bool modifie = false;
        //    var properties = typeof(MembrePourModifierOtd).GetProperties();
        //    foreach (var prop in properties)
        //    {
        //        var newValue = prop.GetValue(MembreOtd);
        //        var currentValue = membreDb.GetType().GetProperty(prop.Name)?.GetValue(membreDb);
        //        if (!Equals(newValue, currentValue))
        //        {
        //            membreDb.GetType().GetProperty(prop.Name)?.SetValue(membreDb, newValue);
        //            //prop.SetValue(membreDb, newValue);
        //            modifie = true;
        //        }
        //    }
        //    return modifie;
        //}
    }
}
