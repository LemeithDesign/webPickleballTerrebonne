using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using web_PickleballTerrebonne.Data.Depot;
using web_PickleballTerrebonne.Data.Entites;
using web_PickleballTerrebonne.ObjetTransfertDonnee.Inscription;

namespace web_PickleballTerrebonne.Pages.Inscriptions
{
    public class IndexModel(IMapper mapper, IInscriptionData inscriptionData) : PageModel
    {
        private readonly IInscriptionData _inscriptionData = inscriptionData;
        private readonly IMapper _mapper = mapper;

        public List<InscriptionPourIndexOtd>? Inscriptions { get; set; }

        public async Task OnGetAsync()
        {
            var inscriptions = await _inscriptionData.ObtenirInscriptions();
            Inscriptions = _mapper.Map<List<InscriptionPourIndexOtd>>(inscriptions);
        }
    }
}
