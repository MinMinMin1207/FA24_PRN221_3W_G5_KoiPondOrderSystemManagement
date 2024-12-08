using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrderSystemManagement.Repositories.DTOs;
using KoiPondOrderSystemManagement.Repositories.Models;

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

            if (loginAccount.Role.Equals("Customer"))
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

            var user = await _userService.GetById(UserUpdate.UserId);
            if (!UserUpdate.Email.ToLower().Equals(user.Email.ToLower()))
            {
                var exist = await _userService.CheckIfExistedEmail(UserUpdate.Email);
                if (exist)
                {
                    ModelState.AddModelError("UserUpdate.Email", "There is an account with this email. Please input another email!");
                    return Page();
                }
            }

            var today = DateOnly.FromDateTime(DateTime.Now);
            var yearsOld = today.Year - UserUpdate.DateOfBirth.Value.Year;
            if (yearsOld < 18)
            {
                ModelState.AddModelError("UserUpdate.DateOfBirth", "The years old must be >= 18!");
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
