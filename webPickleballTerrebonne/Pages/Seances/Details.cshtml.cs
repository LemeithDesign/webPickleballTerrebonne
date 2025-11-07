using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webPickleballTerrebonne.Data.Depot;
using webPickleballTerrebonne.Data.Entites;
using webPickleballTerrebonne.ObjetTransfertDonnee.Seances;

namespace webPickleballTerrebonne.Pages.Seances
{
    public class DetailsModel(ISeanceData gestSeance) : PageModel
    {
        private readonly ISeanceData _gestSeance = gestSeance;

        [BindProperty(SupportsGet = true)]
        public int IdSeance { get; set; } = default!;


        public SeancePourDetailOtd SeanceOtd { get; private set; } = default!;

        public async Task OnGetAsync()
        {
            Seance? seanceDb = await _gestSeance.ObtenirSeanceParId(IdSeance);
            if (seanceDb is null)
            {
                return;
            }
            SeanceOtd = seanceDb.Adapt<SeancePourDetailOtd>();
        }
    }
}
