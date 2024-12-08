using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrder.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.Promotions
{
    public class CreateModel : PageModel
    {
        private readonly PromotionService _promotionService;


        public CreateModel(PromotionService promotionService)
        {
            _promotionService = promotionService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Promotion Promotion { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _promotionService.Create(Promotion);
            TempData["Message"] = "Create success";

            return RedirectToPage("./Index");
        }
    }
}
