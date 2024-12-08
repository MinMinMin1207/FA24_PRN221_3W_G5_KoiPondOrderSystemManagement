using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using KoiPondOrderSystemManagement.Services;
using KoiPondOrderSystemManagement.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.PondManage
{
    public class CreateModel : PageModel
    {
        private readonly PondsService _pondService;
        private readonly UserService _userService;

        public CreateModel(PondsService pondsService, UserService userService)
        {
            _pondService = pondsService;
            _userService = userService;
        }

        public async Task<IActionResult> OnGet()
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
            ViewData["Customers"] = new SelectList(await _userService.GetAllCustomer(), "Id", "FullName");
            ViewData["ConsultingStaff"] = new SelectList(await _userService.GetAllConsultingStaff(), "Id", "FullName");
            ViewData["DesignStaff"] = new SelectList(await _userService.GetAllDesignStaff(), "Id", "FullName");
            ViewData["ConstructionStaff"] = new SelectList(await _userService.GetAllConstructionStaff(), "Id", "FullName");
            ViewData["Designs"] = new SelectList(await _pondService.GetAllDesigns(), "Id", "DesignName");
            ViewData["Payments"] = new SelectList(await _pondService.GetAllPayments(), "Id", "PaymentMethod");
            ViewData["Promotions"] = new SelectList(await _pondService.GetAllPromotions(), "Id", "PromotionName");
            ViewData["Statuses"] = new SelectList(new List<string> { "Pending", "Completed", "In Progress" });
            return Page();
        }

        [BindProperty]
        public Pond Pond { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //var result = _userService.Create(User);
            await _pondService.Create(Pond);

            return RedirectToPage("./Index");
        }
        
    }
}
