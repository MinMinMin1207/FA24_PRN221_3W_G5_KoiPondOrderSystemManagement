using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages
{
    public class LogOutModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Login");
        }
    }
}
