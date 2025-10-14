using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using webPickleballTerrebonne.Data.Entites;

namespace webPickleballTerrebonne.Areas.Identity.Pages.Account
{
    public class ConfirmEmailChangeModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

        [TempData]
        public string StatusMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(string userId, string email, string code)
        {
            if (userId == null || email == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Impossible de charger l'utilisateur avec l'ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ChangeEmailAsync(user, email, code);
            if (!result.Succeeded)
            {
                StatusMessage = "Erreur lors de la modification de l'adresse courriel";
                return Page();
            }

            // Dans notre interface utilisateur, l'adresse e-mail et le nom d'utilisateur sont identiques.
            // Par conséquent, lorsque nous mettons à jour l'adresse e-mail, nous devons également mettre à jour le nom d'utilisateur.
            var setUserNameResult = await _userManager.SetUserNameAsync(user, email);
            if (!setUserNameResult.Succeeded)
            {
                StatusMessage = "Erreur lors du changement de nom d'utilisateur.";
                return Page();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Merci d'avoir confirmé votre adresse courriel.";
            return Page();
        }
    }
}