//using MapsterMapper;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using webPickleballTerrebonne.Data.Depot;
//using webPickleballTerrebonne.Data.Entites;
//using webPickleballTerrebonne.ObjetTransfertDonnee.Inscription;

//namespace webPickleballTerrebonne.Pages.Inscriptions
//{
//    public class ValidationModel(IMapper mapper, IInscriptionData inscriptionData) : PageModel
//    {
//        private readonly IInscriptionData _inscriptionData = inscriptionData;
//        private readonly IMapper _mapper = mapper;

//        public InscriptionPourValidationOtd InscriptionOtd { get; set; } = default!;

//        public async Task<IActionResult> OnGetAsync(int id)
//        {
//            Inscription? inscriptionDb = await _inscriptionData.ObtenirInscriptionParId(id);
//            if (inscriptionDb is null)
//                return RedirectToPage("/Inscriptions/Erreur");

//            InscriptionOtd = _mapper.Map<InscriptionPourValidationOtd>(inscriptionDb);
//            return Page();
//        }
//    }
//}
