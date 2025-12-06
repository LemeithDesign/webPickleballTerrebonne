using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webPickleballTerrebonne.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            return NotFound();
        }
        //public void OnGet()
        //{ }
    }
}