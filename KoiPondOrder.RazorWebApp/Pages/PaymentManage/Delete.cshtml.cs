using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrderSystemManagement.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.PaymentManage
{
    public class DeleteModel : PageModel
    {
        private readonly PaymentService _paymentService;
        private readonly OrderPaymentService _orderPaymentService;
        private readonly PondsService _pondsService;
        private readonly ServicesService _servicesService;

        public DeleteModel(PaymentService paymentService, OrderPaymentService orderPaymentService, PondsService pondsService, ServicesService servicesService)
        {
            _paymentService = paymentService;
            _orderPaymentService = orderPaymentService;
            _pondsService = pondsService;
            _servicesService = servicesService;
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

            if (!loginAccount.Role.Equals("Admin"))
            {
                return StatusCode(403);
            }

            if (id == null)
            {
                return NotFound();
            }

            var payment = await _paymentService.GetById(id ?? default(int));

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _paymentService.GetById(id ?? default(int));
            if (payment != null)
            {
                Payment = payment;
                var order = await _orderPaymentService.GetById(payment.OrderId);
                order.PaymentId = null;
                var listPonds = await _pondsService.GetPondListByPaymentId(id.Value);
                foreach (var item in listPonds)
                {
                    item.PaymentId = null;
                }
                var services = await _servicesService.GetAll();
                foreach (var service in services)
                {
                    service.PaymentId = null;
                }
                await _servicesService.UpdateRange(services);
                await _pondsService.UpdateRange(listPonds);
                await _orderPaymentService.Update(order);
                await _paymentService.Delete(payment);
                TempData["SuccessMessage"] = "Payment deleted successfully!";
            }

            return RedirectToPage("./Index");
        }
    }
}
