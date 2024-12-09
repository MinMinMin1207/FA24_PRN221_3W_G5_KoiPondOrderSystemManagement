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
    public class DeleteModel : PageModel
    {
        private readonly DesignService _designService;

        public DeleteModel(DesignService designService)
        {
            _designService = designService;
        }

        [BindProperty]
        public Design Design { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var loginAccount = SessionHelper.GetLoginAccount(HttpContext.Session, "LoginAccount");

            if (loginAccount == null)
            {
                return Redirect("/Login");
            }

            if (!loginAccount.Role.Equals("Admin"))
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var design = await _designService.GetById(id ?? default(int));
            if (design != null)
            {
                Design = design;
                await _designService.Delete(design);
            }

            return RedirectToPage("./Index");
        }
    }
}
