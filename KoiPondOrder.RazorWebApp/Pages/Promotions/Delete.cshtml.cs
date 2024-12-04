using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrder.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.Promotions
{
    public class DeleteModel : PageModel
    {
        private readonly PromotionService _promotionService;


        public DeleteModel(PromotionService promotionService)
        {
            _promotionService = promotionService;
        }
        [BindProperty]
        public Promotion Promotion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotion = await _promotionService.GetById(id ?? default(int));

            if (promotion == null)
            {
                return NotFound();
            }
            else
            {
                Promotion = promotion;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotion = await _promotionService.GetById(id ?? default(int));
            if (promotion != null)
            {
                Promotion = promotion;
                await _promotionService.Delete(promotion);
                TempData["Message"] = "Delete success";
                 
            }

            return RedirectToPage("./Index");
        }
    }
}
