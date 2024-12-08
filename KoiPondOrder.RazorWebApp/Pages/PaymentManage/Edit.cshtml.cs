using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiPondOrder.Repositories.Models;
using KoiPondOrderSystemManagement.Repositories.DTOs;
using KoiPondOrderSystemManagement.Services;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.PaymentManage
{
    public class EditModel : PageModel
    {
        private readonly PaymentService _paymentService;
        private readonly OrderPaymentService _orderPaymentService;

        public EditModel(PaymentService paymentService, OrderPaymentService orderPaymentService)
        {
            _paymentService = paymentService;
            _orderPaymentService = orderPaymentService;
        }

        [BindProperty]
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
            ViewData["PaymentMethod"] = new SelectList(PaymentMethod.GetMethodList(), "Name", "Name", payment.PaymentMethod);
            ViewData["PaymentStatus"] = new SelectList(PaymentStatus.GetStatusList(), "Name", "Name", payment.PaymentStatus);

            if (payment == null)
            {
                return NotFound();
            }

            Payment = payment;
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

            try
            {
                var order = await _orderPaymentService.GetById(Payment.OrderId);

                if (Payment.PaymentStatus.Equals("Paid"))
                {
                    order.OrderStatus = "Completed";
                }
                else if (Payment.PaymentStatus.Equals("Cancelled"))
                {
                    order.OrderStatus = "Cancelled";
                }

                await _orderPaymentService.Update(order);
                await _paymentService.Update(Payment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(Payment.PaymentId))
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

        private bool PaymentExists(int id)
        {
            var result = _paymentService.GetById(id);
            if (result == null)
            {
                return false;
            }
            return true;
        }
    }
}
