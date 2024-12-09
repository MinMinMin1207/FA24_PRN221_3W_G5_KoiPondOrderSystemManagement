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

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.Promotions
{
    public class EditModel : PageModel
    {
        private readonly PromotionService _promotionService;


        public EditModel(PromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [BindProperty]
        public Promotion Promotion { get; set; } = default!;

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

            var promotion = await _promotionService.GetById(id ?? default(int));
            if (promotion == null)
            {
                return NotFound();
            }
            Promotion = promotion;
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

            //_context.Attach(Promotion).State = EntityState.Modified;

            try
            {
                await _promotionService.Update(Promotion);
                TempData["Message"] = "Update success";


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionExists(Promotion.PromotionId))
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

        private bool PromotionExists(int id)
        {
            var result = _promotionService.GetById(id);
            if (result == null)
            {
                return false;
            }
            return true;
        }
    }
}
