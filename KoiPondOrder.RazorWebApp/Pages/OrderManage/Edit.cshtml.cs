using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrderSystemManagement.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.OrderManage
{
    public class EditModel : PageModel
    {
        //private readonly zPayment.Repositories.Models.FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext _context;
        private readonly OrderService _orderService;
        private readonly PaymentService _paymentService;
        private readonly PromotionService _promotionService;
        private readonly UserService _userService;
        //public EditModel(zPayment.Repositories.Models.FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext context)
        //{
        //    _context = context;
        //}
        public EditModel(OrderService orderService, PaymentService paymentService, PromotionService promotionService,
            UserService userService)
        {
            _orderService = orderService;
            _paymentService = paymentService;
            _promotionService = promotionService;
            _userService = userService;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
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

            if (id <= 0)
            {
                return NotFound();
            }

            var order =  await _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            Order = order;
            var users = await _userService.GetAll();
            if (users == null || !users.Any())
            {
                throw new Exception("User data not found");
            }
            var payments = await _paymentService.GetAll();
            if (payments == null || !payments.Any())
            {
                throw new Exception("User data not found");
            }
            var promotions = await _promotionService.GetAll();
            if (promotions == null || !promotions.Any())
            {
                throw new Exception("User data not found");
            }
            ViewData["CustomerId"] = new SelectList(users, "UserId", "Email");
           ViewData["PaymentId"] = new SelectList(payments, "PaymentId", "PaymentMethod");
           ViewData["PromotionId"] = new SelectList(promotions, "PromotionId", "PromotionName");
            return Page();
        }

    
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //}
            await _orderService.Update(Order);
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!OrderExists(Order.OrderId))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            return RedirectToPage("./Index");
        }

        //private bool OrderExists(int id)
        //{
        //    return _context.Orders.Any(e => e.OrderId == id);
        //}
    }
}
