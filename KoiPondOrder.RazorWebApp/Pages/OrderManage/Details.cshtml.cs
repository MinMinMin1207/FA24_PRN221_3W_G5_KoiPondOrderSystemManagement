﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrderSystemManagement.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.OrderManage 
{ 
    public class DetailsModel : PageModel
{
    //private readonly zPayment.Repositories.Models.FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext _context;
    private readonly OrderService _orderService;
    private readonly PaymentService _paymentService;
    private readonly PromotionService _promotionService;
    private readonly UserService _userService;
    //public DetailsModel(zPayment.Repositories.Models.FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext context)
    //{
    //    _context = context;
    //}
    public DetailsModel(OrderService orderService, PaymentService paymentService, PromotionService promotionService,
        UserService userService)
    {
        _orderService = orderService;
        _paymentService = paymentService;
        _promotionService = promotionService;
        _userService = userService;
    }

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
}
}
