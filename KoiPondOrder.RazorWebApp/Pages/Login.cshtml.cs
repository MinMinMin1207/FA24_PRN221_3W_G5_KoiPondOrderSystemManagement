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

                    HttpContext.Session.SetString("UserEmail", user.Email);
                    HttpContext.Session.SetString("UserRole", user.Role);

                    return RedirectToPage("/Index");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return Page();
        }
    }
}
