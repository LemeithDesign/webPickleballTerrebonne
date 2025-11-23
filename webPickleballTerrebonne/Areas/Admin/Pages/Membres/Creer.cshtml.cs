using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webPickleballTerrebonne.Data.Depot;
using webPickleballTerrebonne.Data.Entites;
using webPickleballTerrebonne.ObjetTransfertDonnee.Membre;

namespace webPickleballTerrebonne.Areas.Admin.Pages.Membres
{
    public class CreerModel(IMembreData gestMembres, IUserStore<ApplicationUser> userStore, UserManager<ApplicationUser> userManager) : PageModel
    {
        private readonly IMembreData _gestMembres = gestMembres;
        private readonly IUserStore<ApplicationUser> _userStore = userStore;
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        [BindProperty]
        public MembrePourCreerOtd MembreOtd { get; set; } = default!;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Membre membreDb = MembreOtd.Adapt<Membre>();
                int idMembre = await _gestMembres.CreerMembreAsync(membreDb);

                ApplicationUser user = Activator.CreateInstance<ApplicationUser>();
                await _userStore.SetUserNameAsync(user, MembreOtd.Courriel, CancellationToken.None);

                user.Membre = membreDb;
                user.MembreId = idMembre;
                user.Email = MembreOtd.Courriel;
                user.MembreActif = false;
                // Pour tests:
                user.EmailConfirmed = true;
                //membreDb.DateMembreActif = DateTime.Now;

                await _userManager.CreateAsync(user, MembreOtd.Password);
            }
            return RedirectToPage("Index");
        }
    }
}
