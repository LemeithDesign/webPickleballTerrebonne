using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webPickleballTerrebonne.Data.Depot;
using webPickleballTerrebonne.Data.Entites;
using webPickleballTerrebonne.ObjetTransfertDonnee.Participations;
using webPickleballTerrebonne.ObjetTransfertDonnee.PlagesHoraires;

namespace webPickleballTerrebonne.Pages.Participations
{
    public class IndexModel(IParticipationData gestParticipations) : PageModel
    {
        private readonly IParticipationData _gestParticipations = gestParticipations;

        //public List<ParticipationPourIndexOtd> ParticipationsOtd { get; set; } = [];

        //public Dictionary<DayOfWeek, List<ParticipationPourIndexOtd>>? ParticipationsOtd { get; set; }
        public Dictionary<DateTime, List<ParticipationPourIndexOtd>>? Semaine { get; set; }

        public IActionResult OnGet() => NotFound();

        //public async Task OnGetAsync(int semaine = 0)
        //{
        //    List<Participation> lsParticipations = await _gestParticipations.ObtenirParticipationsAsync();
        //    List<ParticipationPourIndexOtd> lsParticipationsOtd = lsParticipations.Adapt<List<ParticipationPourIndexOtd>>();

        //    // Obtenir les journées
        //    var aujour = DateTime.Today;
        //    var debutSemaine = aujour.AddDays((int)DayOfWeek.Sunday - (int)aujour.DayOfWeek).AddDays(semaine * 7);

        //    Semaine = [];

        //    for (int i = 0; i < 7; i++)
        //    {
        //        var date = debutSemaine.AddDays(i);
        //        var activite = lsParticipationsOtd
        //            .Where(p => p.Jour == date.DayOfWeek)
        //            .ToList();

        //        Semaine[date] = activite;
        //    }

        //    //ParticipationsOtd = lsParticipationsOtd
        //    //    .GroupBy(s => s.Jour)
        //    //    .ToDictionary(g => g.Key, g => g.OrderBy(s => s.HeureDebut).ToList());
        //}
    }
}