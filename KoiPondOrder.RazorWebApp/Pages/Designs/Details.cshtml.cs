using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrderSystemManagement.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.Designs
{
    public class DetailsModel : PageModel
    {
        private readonly DesignService _designService;
        public DetailsModel(DesignService designService)
        {
            _designService = designService;
        }

        public Design Design { get; set; } = default!;

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

            var design = await _designService.GetById(id ?? default(int));
            if (design == null)
            {
                return NotFound();
            }
            else
            {
                Design = design;
            }
            return Page();
        }
    }
}
