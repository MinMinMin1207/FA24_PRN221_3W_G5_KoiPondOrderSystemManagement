using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrderSystemManagement.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.UserManage
{
    public class CreateModel : PageModel
    {
        private readonly UserService _userService;

        public CreateModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.

        public async Task<IActionResult> OnGetAsync()
        {
            var loginAccount = SessionHelper.GetLoginAccount(HttpContext.Session, "LoginAccount");

            if (loginAccount == null)
            {
                return Redirect("/Login");
            }

            if (loginAccount.Role.Equals("Customer"))
            {
                return StatusCode(403);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var exist = await _userService.CheckIfExistedEmail(User.Email);

            if (exist)
            {
                ModelState.AddModelError("User.Email", "There is an account with this email. Please input another email!");
                return Page();
            }

            var today = DateOnly.FromDateTime(DateTime.Now);
            var yearsOld = today.Year - User.DateOfBirth.Value.Year;

            if (yearsOld < 18)
            {
                ModelState.AddModelError("User.DateOfBirth", "The years old must be >= 18!");
                return Page();
            }

            var password = BCrypt.Net.BCrypt.HashPassword(User.PasswordHash);
            User.PasswordHash = password;
            User.Status = true;
            await _userService.Create(User);

            return RedirectToPage("./Index");
        }
    }
}
