using Mapster;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webPickleballTerrebonne.Data.Depot;
using webPickleballTerrebonne.Data.Entites;
using webPickleballTerrebonne.ObjetTransfertDonnee.Seances;

namespace webPickleballTerrebonne.Pages.Seances
{
    public class IndexModel(ISeanceData gestSeance) : PageModel
    {
        private readonly ISeanceData _gestSeance = gestSeance;

        public Dictionary<DayOfWeek, List<SeancePourIndexOtd>>? Seances { get; set; }

        public async Task OnGetAsync()
        {
            List<Seance> lsSeances = await _gestSeance.ObtenirSeances();

            List<SeancePourIndexOtd> lsSeancesOtd = lsSeances.Adapt<List<SeancePourIndexOtd>>();

            Seances = lsSeancesOtd
                .GroupBy(s => s.Jour)
                .ToDictionary(g => g.Key, g => g.OrderBy(s => s.HeureDebut).ToList());

        }
    }
}