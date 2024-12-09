using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrderSystemManagement.Repositories.DTOs;
using KoiPondOrderSystemManagement.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.PaymentManage
{
    public class CreateModel : PageModel
    {
        private readonly PaymentService _paymentService;
        private readonly OrderPaymentService _orderPaymentService;

        public CreateModel(PaymentService paymentService, OrderPaymentService orderPaymentService)
        {
            _paymentService = paymentService;
            _orderPaymentService = orderPaymentService;
        }

        public int OrderId { get; set; }

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
            var orderList = await _orderPaymentService.GetPendingOrders();
            ViewData["OrderId"] = new SelectList(orderList, "OrderId", "OrderId");
            return Page();
        }

        [BindProperty]
        public Payment Payment { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var order = await _orderPaymentService.GetById(Payment.OrderId);
            await _paymentService.Create(Payment);
            order.PaymentId = Payment.PaymentId;
            await _orderPaymentService.Update(order);
            TempData["SuccessMessage"] = "Payment created successfully!";
            return RedirectToPage("./Index");
        }

        public async Task<JsonResult> OnGetOrderDetails(int orderId)
        {
            var orderDetails = await _orderPaymentService.GetOrderDetails(orderId);
            return new JsonResult(new
            {
                amount = orderDetails.Amount,
                tax = orderDetails.Tax,
                discount = orderDetails.Discount,
                finalAmount = orderDetails.FinalAmount
            });
        }
    }

}
