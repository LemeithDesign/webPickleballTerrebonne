using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using web_PickleballTerrebonne.Data.Depot;
using web_PickleballTerrebonne.Data.Entites;
using web_PickleballTerrebonne.ObjetTransfertDonnee.Inscription;

namespace web_PickleballTerrebonne.Pages.Inscriptions
{
    public class DetailsModel(IMapper mapper, IInscriptionData inscriptionData) : PageModel
    {
        private readonly IInscriptionData _inscriptionData = inscriptionData;
        private readonly IMapper _mapper = mapper;

        public InscriptionPourDetailsOtd InscriptionOtd { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Inscription? inscriptionDb = await _inscriptionData.ObtenirInscriptionParId(id);
            if (inscriptionDb is null)
                return RedirectToPage("Index");

            InscriptionOtd = _mapper.Map<InscriptionPourDetailsOtd>(inscriptionDb);
            return Page();
        }
    }
}

