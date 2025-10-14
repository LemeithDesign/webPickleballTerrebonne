//using MapsterMapper;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using webPickleballTerrebonne.Data.Depot;
//using webPickleballTerrebonne.Data.Entites;
//using webPickleballTerrebonne.ObjetTransfertDonnee.Inscription;

//namespace webPickleballTerrebonne.Pages.Inscriptions
//{
//    public class CreerModel(IMapper mapper, IInscriptionData inscriptionData) : PageModel
//    {
//        private readonly IInscriptionData _inscriptionData = inscriptionData;
//        private readonly IMapper _mapper = mapper;

//        [BindProperty]
//        public InscriptionPourCreerOtd InscriptionOtd { get; set; } = default!;

//        public void OnGet()
//        {
//        }

//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (ModelState.IsValid)
//            {
//                Inscription inscriptionDb = _mapper.Map<Inscription>(InscriptionOtd);

//                int inscriptionId = await _inscriptionData.CreerInscriptionAsync(inscriptionDb);

//                return RedirectToPage("/inscriptions/Validation", new { id = inscriptionId });
//            }
//            return Page();
//        }
//    }
//}