using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using webPickleballTerrebonne.Data.Entites;

namespace webPickleballTerrebonne.Areas.Identity.Pages.Account
{
    public class LoginWith2faModel(SignInManager<ApplicationUser> signInManager) : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
        //private readonly UserManager<ApplicationUser> _userManager = userManager;


        [BindProperty]
        public InputModel Input { get; set; } = default!;

        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; } = string.Empty;

        public class InputModel
        {
            [Required]
            [StringLength(7, ErrorMessage = "Le {0} doit comporter au moins {2} et au maximum {1} caractères.", MinimumLength = 6)]
            [DataType(DataType.Text)]
            [Display(Name = "Code d'authentification")]
            public string TwoFactorCode { get; set; } = string.Empty;

            [Display(Name = "Se souvenir de cette machine")]
            public bool RememberMachine { get; set; }
        }

        public IActionResult OnGet()
        {
            return NotFound();
        }

        //public async Task<IActionResult> OnGetAsync(bool rememberMe, string? returnUrl = null)
        //{
        //    // Ensure the user has gone through the username & password screen first
        //    var user = await _signInManager.GetTwoFactorAuthenticationUserAsync()
        //        ?? throw new InvalidOperationException("Impossible de charger l'utilisateur de l'authentification à deux facteurs..");

        //    ReturnUrl = returnUrl;
        //    RememberMe = rememberMe;

        //    return Page();
        //}

        //public async Task<IActionResult> OnPostAsync(bool rememberMe, string? returnUrl = null)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    returnUrl ??= Url.Content("~/");

        //    var user = await _signInManager.GetTwoFactorAuthenticationUserAsync()
        //        ?? throw new InvalidOperationException("Impossible de charger l'utilisateur de l'authentification à deux facteurs.");

        //    var authenticatorCode = Input.TwoFactorCode.Replace(" ", string.Empty).Replace("-", string.Empty);

        //    var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(authenticatorCode, rememberMe, Input.RememberMachine);

        //    //var userId = await _userManager.GetUserIdAsync(user);

        //    if (result.Succeeded)
        //    {
        //        return LocalRedirect(returnUrl);
        //    }
        //    else if (result.IsLockedOut)
        //    {
        //        return RedirectToPage("./Lockout");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(string.Empty, "Code d'authentification invalide.");
        //        return Page();
        //    }
        //}
    }
}
