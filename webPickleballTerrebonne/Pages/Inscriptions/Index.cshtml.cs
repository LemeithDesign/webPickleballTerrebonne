//using MapsterMapper;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using webPickleballTerrebonne.Data.Depot;
//using webPickleballTerrebonne.Data.Entites;
//using webPickleballTerrebonne.ObjetTransfertDonnee.Inscription;

//namespace webPickleballTerrebonne.Pages.Inscriptions
//{
//    public class IndexModel(IMapper mapper, IInscriptionData inscriptionData) : PageModel
//    {
//        private readonly IInscriptionData _inscriptionData = inscriptionData;
//        private readonly IMapper _mapper = mapper;

//        public List<InscriptionPourIndexOtd>? Inscriptions { get; set; }

//        public async Task OnGetAsync()
//        {
//            var inscriptions = await _inscriptionData.ObtenirInscriptions();
//            Inscriptions = _mapper.Map<List<InscriptionPourIndexOtd>>(inscriptions);
//        }
//    }
//}
