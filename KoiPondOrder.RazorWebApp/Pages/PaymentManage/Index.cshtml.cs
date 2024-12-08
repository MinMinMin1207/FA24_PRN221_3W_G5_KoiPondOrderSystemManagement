using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiPondOrder.Repositories.Models;
using KoiPondOrderSystemManagement.Repositories.DTOs;
using KoiPondOrderSystemManagement.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.PaymentManage
{
    public class IndexModel : PageModel
    {
        private readonly PaymentService _paymentService;

        public IndexModel(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public Pagination<Payment> Payments { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? PaymentMethod { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? FromDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? ToDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? PaymentStatus { get; set; }

        public List<SelectListItem> PaymentMethods { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "-- All --" },
            new SelectListItem { Value = "BankTransfer", Text = "BankTransfer" },
            new SelectListItem { Value = "Card", Text = "Card" },
            new SelectListItem { Value = "Cash", Text = "Cash" }
        };

        public List<SelectListItem> PaymentsStatus { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "-- All --" },
            new SelectListItem { Value = "Paid", Text = "Paid" },
            new SelectListItem { Value = "Cancelled", Text = "Cancelled" },
            new SelectListItem { Value = "Pending", Text = "Pending" }
        };


        public async Task<IActionResult> OnGetAsync(int? pageIndex)
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

            var listPayment = new List<Payment>();

            listPayment = _paymentService.Search(PaymentMethod, FromDate, ToDate, PaymentStatus);

            Payments = Pagination<Payment>.Create(listPayment, pageIndex ?? 1, pageSize: 5);
            return Page();
        }
    }
}
