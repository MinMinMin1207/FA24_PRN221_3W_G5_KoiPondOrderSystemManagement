using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiPondOrder.Repositories.Models;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrderSystemManagement.Repositories;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.PaymentManage
{
    public class DetailsModel : PageModel
    {
        private readonly PaymentService _paymentService;

        public DetailsModel(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public Payment Payment { get; set; } = default!;

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

            var payment = await _paymentService.GetById(id.Value);
            if (payment == null)
            {
                return NotFound();
            }
            else
            {
                Payment = payment;
            }
            return Page();
        }
    }
}
