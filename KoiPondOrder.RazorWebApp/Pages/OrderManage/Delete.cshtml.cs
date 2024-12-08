using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiPondOrderSystemManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiPondOrder.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.OrderManage
{
    public class DeleteModel : PageModel
    {
        //private readonly zPayment.Repositories.Models.FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext _context;
        private readonly OrderService _orderService;
        private readonly PaymentService _paymentService;
        private readonly PromotionService _promotionService;
        private readonly UserService _userService;
        //public DeleteModel(zPayment.Repositories.Models.FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext context)
        //{
        //    _context = context;
        //}
        public DeleteModel(OrderService orderService, PaymentService paymentService, PromotionService promotionService,
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
            if (id == null)
            {
                return NotFound();
            }

            //var order = await _context.Orders.FirstOrDefaultAsync(m => m.OrderId == id);
            var order = await _orderService.GetById(id);

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                Order = order;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var order = await _orderService.GetById(id);
            if (order != null)
            {
                Order = order;
                await _orderService.Delete(order);
            }

            return RedirectToPage("./Index");
        }
    }
}
