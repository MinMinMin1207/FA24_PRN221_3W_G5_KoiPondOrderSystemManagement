using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrderSystemManagement.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.Designs
{
    public class EditModel : PageModel
    {
        private readonly DesignService _designService;
        private readonly PromotionService _promotionService;

        public EditModel(DesignService designService, PromotionService promotionService)
        {
            _designService = designService;
            _promotionService = promotionService;
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
            Design = design;
           ViewData["PromotionId"] = new SelectList(await _promotionService.GetAll(), "PromotionId", "PromotionName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _designService.Update(Design);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignExists(Design.DesignId))
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

        private bool DesignExists(int id)
        {
            var exist = _designService.GetById(id);
            if (exist == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
