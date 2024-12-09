using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrderSystemManagement.Repositories.DTOs;
using KoiPondOrderSystemManagement.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.UserManage
{
    public class IndexModel : PageModel
    {
        private readonly UserService _userService;

        public IndexModel(UserService userService)
        {
            _userService = userService;
        }

        public Pagination<User> User { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public UserSearchModel SearchModel { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? pageIndex)
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

            var listUser = new List<User>();

            if (SearchModel != null)
            {
                listUser = _userService.Search(SearchModel);
            }
            else
            {
                listUser = await _userService.GetAll();
            }

            listUser = listUser.OrderByDescending(x => x.UserId).ToList();

            User = Pagination<User>.Create(listUser, pageIndex ?? 1, pageSize: 5);
            return Page();
        }
    }
}
