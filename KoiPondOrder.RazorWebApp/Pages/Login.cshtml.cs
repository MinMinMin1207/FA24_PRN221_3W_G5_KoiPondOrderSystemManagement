using KoiPondOrderSystemManagement.Repositories.DTOs;
using KoiPondOrderSystemManagement.Repositories.Models;
using KoiPondOrderSystemManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.LoginPage
{
    public class LoginModel : PageModel
    {
        private readonly UserService _userService;
        public LoginModel(UserService userService)
        {
            _userService = userService;

        }
        [BindProperty]
        public LoginRequestModel SystemAccount { get; set; } = default!;

        private void SetSession(User loginAccount)
        {
            SessionHelper.SetObjectAsJson(HttpContext.Session, "LoginAccount", loginAccount);
        }

        public IActionResult OnGetAsync()
        {
            var loginAccount = SessionHelper.GetLoginAccount(HttpContext.Session, "LoginAccount");

            if (loginAccount != null)
            {
                return RedirectToPage("/LogOut/Home");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var logged = _userService.Login(SystemAccount);
            if (logged != null)
            {
                SetSession(logged);
                return RedirectToPage("/LogOut/Home");
            }
            return Page();
        }
    }
}
