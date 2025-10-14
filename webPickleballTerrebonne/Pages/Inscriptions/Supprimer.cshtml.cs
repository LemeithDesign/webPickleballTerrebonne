//using MapsterMapper;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using webPickleballTerrebonne.Data.Depot;
//using webPickleballTerrebonne.Data.Entites;
//using webPickleballTerrebonne.ObjetTransfertDonnee.Inscription;

//namespace webPickleballTerrebonne.Pages.Inscriptions
//{
//    public class SupprimerModel(IMapper mapper, IInscriptionData inscriptionData) : PageModel
//    {
//        private readonly IInscriptionData _inscriptionData = inscriptionData;
//        private readonly IMapper _mapper = mapper;


//        [BindProperty(SupportsGet = true)]
//        public InscriptionPourSupprimerOtd InscriptionOtd { get; set; } = default!;

//        public async Task<IActionResult> OnGetAsync(int id)
//        {
//            Inscription? inscriptionDb = await _inscriptionData.ObtenirInscriptionParId(id);
//            if(inscriptionDb is null)
//                return RedirectToPage("Index");

//            InscriptionOtd = _mapper.Map<InscriptionPourSupprimerOtd>(inscriptionDb);
//            return Page();
//        }

//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (ModelState.IsValid)
//            {
//                Inscription? inscriptionDb = await _inscriptionData.ObtenirInscriptionParId(InscriptionOtd.Id);
//                if (inscriptionDb is null)
//                    return RedirectToPage("Index");
//                _inscriptionData.SupprimerMusicien(inscriptionDb);
//                await _inscriptionData.SauvegarderAsync();
//                return RedirectToPage("Index");
//            }
//            return Page();
//        }
//    }
//}