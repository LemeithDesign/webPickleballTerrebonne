using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using webPickleballTerrebonne.Data.Entites;

namespace webPickleballTerrebonne.Areas.Identity.Pages.Account
{
    public class LoginWithRecoveryCodeModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
        private readonly UserManager<ApplicationUser> _userManager= userManager;

        [BindProperty]
        public InputModel Input { get; set; } = default!;

        public string? ReturnUrl { get; set; }

        public class InputModel
        {
            [BindProperty]
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Code de récupération")]
            public string RecoveryCode { get; set; } = string.Empty;
        }

        public IActionResult OnGet()
        {
            return NotFound();
        }

        //public async Task<IActionResult> OnGetAsync(string? returnUrl = null)
        //{
        //    // Ensure the user has gone through the username & password screen first
        //    var user = await _signInManager.GetTwoFactorAuthenticationUserAsync()
        //        ?? throw new InvalidOperationException($"Impossible de charger l'utilisateur de l'authentification à deux facteurs.");

        //    ReturnUrl = returnUrl;

        //    return Page();
        //}

        //public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    var user = await _signInManager.GetTwoFactorAuthenticationUserAsync()
        //        ?? throw new InvalidOperationException($"Impossible de charger l'utilisateur de l'authentification à deux facteurs.");

        //    var recoveryCode = Input.RecoveryCode.Replace(" ", string.Empty);

        //    var result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

        //    //var userId = await _userManager.GetUserIdAsync(user);

        //    if (result.Succeeded)
        //    {
        //        return LocalRedirect(returnUrl ?? Url.Content("~/"));
        //    }
        //    if (result.IsLockedOut)
        //    {
        //        return RedirectToPage("./Lockout");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(string.Empty, "Code de récupération invalide saisi.");
        //        return Page();
        //    }
        //}
    }
}
