using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using web_PickleballTerrebonne.Data.Depot;
using web_PickleballTerrebonne.Data.Entites;
using web_PickleballTerrebonne.ObjetTransfertDonnee.Inscription;

namespace web_PickleballTerrebonne.Pages.Inscriptions
{
    public class CreerModel(IMapper mapper, IInscriptionData inscriptionData) : PageModel
    {
        private readonly IInscriptionData _inscriptionData = inscriptionData;
        private readonly IMapper _mapper = mapper;

        [BindProperty]
        public InscriptionPourCreerOtd InscriptionOtd { get; set; } = default!;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Inscription inscriptionDb = _mapper.Map<Inscription>(InscriptionOtd);

                await _inscriptionData.CreerInscriptionAsync(inscriptionDb);
                await _inscriptionData.SauvegarderAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}