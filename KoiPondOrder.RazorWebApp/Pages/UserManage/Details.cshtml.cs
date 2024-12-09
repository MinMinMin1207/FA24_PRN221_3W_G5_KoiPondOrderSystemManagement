using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrderSystemManagement.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.UserManage
{
    public class DetailsModel : PageModel
    {

        private readonly UserService _userService;

        public DetailsModel(UserService userService)
        {
            _userService = userService;
        }

        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var loginAccount = SessionHelper.GetLoginAccount(HttpContext.Session, "LoginAccount");

            if (loginAccount == null)
            {
                return Redirect("/Login");
            }

            if (!loginAccount.Role.Equals("Admin") && !loginAccount.Role.Equals("Manager"))
            {
                return StatusCode(403);
            }

            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetById(id ?? default(int));
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                User = user;
            }
            return Page();
        }
    }
}
