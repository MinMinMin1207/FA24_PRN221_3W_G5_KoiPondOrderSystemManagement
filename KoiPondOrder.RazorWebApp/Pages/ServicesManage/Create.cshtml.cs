using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using KoiPondOrderSystemManagement.Services;
using KoiPondOrderSystemManagement.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.ServicesManage
{
    public class CreateModel : PageModel
    {
        private readonly ServicesService _servicesService;
        public CreateModel(ServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        public IActionResult OnGet()
        {
            //ViewData["CustomerId"] = new SelectList(_context.Users, "UserId", "Email");
            //ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "PaymentMethod");
            //ViewData["PromotionId"] = new SelectList(_context.Promotions, "PromotionId", "PromotionName");
            //ViewData["StaffId"] = new SelectList(_context.Users, "UserId", "Email");
            var loginAccount = SessionHelper.GetLoginAccount(HttpContext.Session, "LoginAccount");

            if (loginAccount == null)
            {
                return Redirect("/Login");
            }
            if (loginAccount.Role.Equals("Customer"))
            {
                return StatusCode(403);
            }
            return Page();
        }

        [BindProperty]
        public Service Service { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //var result = _userService.Create(User);
            await _servicesService.Create(Service);

            return RedirectToPage("./Index");
        }
    }
}
