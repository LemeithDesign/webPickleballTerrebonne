using Mapster;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webPickleballTerrebonne.Data.Depot;
using webPickleballTerrebonne.Data.Entites;
using webPickleballTerrebonne.ObjetTransfertDonnee.PlagesHoraires;

namespace webPickleballTerrebonne.Pages.PlagesHoraires
{
    public class IndexModel(IPlageHoraireData gestPlagesHoraires) : PageModel
    {
        private readonly IPlageHoraireData _gestPlagesHoraires = gestPlagesHoraires;

        public Dictionary<DayOfWeek, List<PlageHorairePourIndexOtd>>? PlagesHorairesOtd { get; set; }

        public async Task OnGetAsync()
        {
            List<PlageHoraire> lsSeances = await _gestPlagesHoraires.ObtenirPlagesHoraires();

            List<PlageHorairePourIndexOtd> lsPlagesHorairesOtd = lsSeances.Adapt<List<PlageHorairePourIndexOtd>>();

            PlagesHorairesOtd = lsPlagesHorairesOtd
                .GroupBy(s => s.Jour)
                .ToDictionary(g => g.Key, g => g.OrderBy(s => s.HeureDebut).ToList());
        }
    }
}