//using MapsterMapper;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using web_PickleballTerrebonne.Data.Depot;
//using web_PickleballTerrebonne.Data.Entites;
//using web_PickleballTerrebonne.ObjetTransfertDonnee.Inscription;

//namespace web_PickleballTerrebonne.Pages.Inscriptions
//{
//    public class ModifierModel(IMapper mapper, IInscriptionData inscriptionData) : PageModel
//    {
//        private readonly IInscriptionData _inscriptionData = inscriptionData;
//        private readonly IMapper _mapper = mapper;

//        [BindProperty(SupportsGet = true)]
//        public InscriptionPourModifierOtd InscriptionOtd { get; set; } = default!;

//        public async Task<IActionResult> OnGetAsync(int id)
//        {
//            Inscription? inscriptionDb = await _inscriptionData.ObtenirInscriptionParId(id);
//            if (inscriptionDb is null)
//                return RedirectToPage("Index");

//            InscriptionOtd = _mapper.Map<InscriptionPourModifierOtd>(inscriptionDb);
//            return Page();
//        }

//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (ModelState.IsValid)
//            {
//                Inscription? inscriptionDb = await _inscriptionData.ObtenirInscriptionParId(InscriptionOtd.Id);
//                if (inscriptionDb is null)
//                    return RedirectToPage("/inscriptions/erreur");

//                Inscription inscriptionModifie = _mapper.Map<Inscription>(InscriptionOtd);
//                await _inscriptionData.ModifierInscription(inscriptionModifie);
//                await _inscriptionData.SauvegarderAsync();
//                return RedirectToPage("/inscriptions/validation", new { id = InscriptionOtd.Id });
//            }
//            return Page();
//        }
//    }
//}