using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.LogOut
{
    public class HomeModel : PageModel
    {
        [BindProperty]
        public string? UserFullName { get; set; }
        public IActionResult OnGet()
        {
            var loginAccount = SessionHelper.GetLoginAccount(HttpContext.Session, "LoginAccount");

            if (loginAccount != null)
            {
                UserFullName = loginAccount.FullName;
                return Page();
            }
            return RedirectToPage("/Login");
        }
    }
}
