using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrderSystemManagement.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.Promotions
{
    public class IndexModel : PageModel
    {
        private readonly PromotionService _promotionService;

        // Bindable properties to receive filter values from query string
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? PointsRequired { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? DiscountPercentage { get; set; }

        public int TotalPages { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 2;

        public IList<Promotion> Promotion { get; set; } = default!;

        public IndexModel(PromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        public async Task<IActionResult> OnGetAsync(int pageIndex = 1)
        {
            var loginAccount = SessionHelper.GetLoginAccount(HttpContext.Session, "LoginAccount");

            if (loginAccount == null)
            {
                return Redirect("/Login");
            }

            if (!loginAccount.Role.Equals("Admin") && !loginAccount.Role.Equals("Manager"))
            {
                return StatusCode(403);
            }
            // Pass filters to the service
            var result = await _promotionService.GetListPaging(
                SearchTerm,
                PointsRequired,
                DiscountPercentage,
                pageIndex,
                PageSize
            );

            var listPromotion = new List<Promotion>();

            if (DiscountPercentage > 100 || DiscountPercentage < 0)
            {
                TempData["Message"] = "DiscountPercentage must be between 0 and 100.";
            }

            Promotion = result.Promotions;
            PageIndex = result.PageIndex;
            TotalPages = result.TotalPages;
            return Page();
        }
    }
}
