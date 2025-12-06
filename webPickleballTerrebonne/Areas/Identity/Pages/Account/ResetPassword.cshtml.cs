using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Text;
using webPickleballTerrebonne.Data.Entites;

namespace webPickleballTerrebonne.Areas.Identity.Pages.Account
{
    public class ResetPasswordModel(UserManager<ApplicationUser> userManager) : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        [BindProperty]
        public InputModel Input { get; set; } = default!;

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required]
            [StringLength(100, ErrorMessage = "Le {0} doit comporter au moins {2} et au maximum {1} caractères.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;

            [DataType(DataType.Password)]
            [Display(Name = "Confirmez le mot de passe")]
            [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
            public string ConfirmPassword { get; set; } = string.Empty;

            [Required]
            public string Code { get; set; } = string.Empty;

        }

        public IActionResult OnGet()
        {
            return NotFound();
        }

        //public IActionResult OnGet(string? code = null)
        //{
        //    if (code == null)
        //    {
        //        return BadRequest("Un code doit être fourni pour réinitialiser le mot de passe.");
        //    }
        //    else
        //    {
        //        Input = new InputModel
        //        {
        //            Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code))
        //        };
        //        return Page();
        //    }
        //}

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    var user = await _userManager.FindByEmailAsync(Input.Email);
        //    if (user == null)
        //    {
        //        // Don't reveal that the user does not exist
        //        return RedirectToPage("./ResetPasswordConfirmation");
        //    }

        //    var result = await _userManager.ResetPasswordAsync(user, Input.Code, Input.Password);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToPage("./ResetPasswordConfirmation");
        //    }

        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError(string.Empty, error.Description);
        //    }
        //    return Page();
        //}
    }
}
