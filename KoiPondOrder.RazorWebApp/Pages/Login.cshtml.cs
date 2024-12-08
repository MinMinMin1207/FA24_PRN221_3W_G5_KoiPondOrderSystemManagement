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
        public InputModel Input { get; set; }

        public string ErrorMessage { get; set; } 

        public class InputModel
        {
            public string Email { get; set; }
            public string PasswordHash { get; set; }
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = _userService.CheckLogin(Input.Email, Input.PasswordHash);
                if (user != null)
                {
            var logged = _userService.Login(SystemAccount);
            if (logged != null)
            {
                SetSession(logged);
                return RedirectToPage("/UserManage/Index");
            }
            return Page();
        }
    }
}
