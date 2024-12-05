using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiPondOrder.Repositories.Models;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrderSystemManagement.Repositories.DTOs;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.UserManage
{
    public class EditModel : PageModel
    {
        private readonly UserService _userService;

        public EditModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User UserUpdate { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var loginAccount = SessionHelper.GetLoginAccount(HttpContext.Session, "LoginAccount");

            if (loginAccount == null)
            {
                return Redirect("/Login");
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
            UserUpdate = user;
            ViewData["AccountRole"] = new SelectList(UserRoles.GetRoleList(), "RoleName", "RoleName", UserUpdate.Role);
            ViewData["AccountGender"] = new SelectList(UserGender.GetGenderList(), "Gender", "Gender", UserUpdate.Gender);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["AccountRole"] = new SelectList(UserRoles.GetRoleList(), "RoleName", "RoleName", UserUpdate.Role);
                ViewData["AccountGender"] = new SelectList(UserGender.GetGenderList(), "Gender", "Gender", UserUpdate.Gender);
                return Page();
            }

            try
            {
                await _userService.Update(UserUpdate);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(UserUpdate.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserExists(int id)
        {
            var result = _userService.GetById(id);
            if (result == null)
            {
                return false;
            }
            return true;
        }
    }
}
