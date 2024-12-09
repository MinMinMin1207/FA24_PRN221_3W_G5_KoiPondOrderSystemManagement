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
    public class CreateModel : PageModel
    {
        //private readonly zPayment.Repositories.Models.FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext _context;
        private readonly OrderService _orderService;
        private readonly PaymentService _paymentService;
        private readonly PromotionService _promotionService;
        private readonly UserService _userService;

        //public CreateModel(zPayment.Repositories.Models.FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext context)
        //{
        //    _context = context;
        //}
        public CreateModel(OrderService orderService, PaymentService paymentService, PromotionService promotionService,
            UserService userService)
        {
            _orderService = orderService;
            _paymentService = paymentService;
            _promotionService = promotionService;
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
            //    ViewData["CustomerId"] = new SelectList(_context.Users, "UserId", "Email");
            //ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "PaymentMethod");
            //ViewData["PromotionId"] = new SelectList(_context.Promotions, "PromotionId", "PromotionName");
            ViewData["CustomerId"] = new SelectList(users, "UserId", "Email");
            ViewData["PaymentId"] = new SelectList(payments, "PaymentId", "PaymentMethod");
            ViewData["PromotionId"] = new SelectList(promotions, "PromotionId", "PromotionName");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //}
            await _orderService.Create(Order);
            //_context.Add(Order);
            //await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
