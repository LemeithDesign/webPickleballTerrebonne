using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webPickleballTerrebonne.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordConfirmationModel : PageModel
    {
        public IActionResult OnGet()
        {
            return NotFound();
        }
        //public void OnGet()
        //{
        //}
    }
}
