using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrderSystemManagement.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.Designs
{
    public class CreateModel : PageModel
    {
        private readonly DesignService _designService;
        private readonly PromotionService _promotionService;

        public CreateModel(DesignService designService, PromotionService promotionService)
        {
            _designService = designService;
            _promotionService = promotionService;
        }

        public async Task<IActionResult> OnGet()
        {
            ViewData["PromotionId"] = new SelectList(await _promotionService.GetAll(), "PromotionId", "PromotionName");
            return Page();
        }

        [BindProperty]
        public Design Design { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _designService.Create(Design);

            return RedirectToPage("./Index");
        }
    }
}
