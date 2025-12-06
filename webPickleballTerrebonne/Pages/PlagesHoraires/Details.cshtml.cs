using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webPickleballTerrebonne.Data.Depot;
using webPickleballTerrebonne.Data.Entites;
using webPickleballTerrebonne.ObjetTransfertDonnee.PlagesHoraires;

namespace webPickleballTerrebonne.Pages.PlagesHoraires
{
    public class DetailsModel(IPlageHoraireData gestPlagesHoraires) : PageModel
    {
        private readonly IPlageHoraireData _gestPlagesHoraires = gestPlagesHoraires;

        [BindProperty(SupportsGet = true)]
        public int IdPlageHoraire { get; set; } = default!;

        public PlageHorairePourDetailOtd PlageHoraireOtd { get; private set; } = default!;

        public IActionResult OnGet() => NotFound();

        //public async Task OnGetAsync()
        //{
        //    PlageHoraire? plageHoraireDb = await _gestPlagesHoraires.ObtenirPlageHoraireParId(IdPlageHoraire);
        //    if (plageHoraireDb is null)
        //    {
        //        return;
        //    }
        //    PlageHoraireOtd = plageHoraireDb.Adapt<PlageHorairePourDetailOtd>();
        //}
    }
}
