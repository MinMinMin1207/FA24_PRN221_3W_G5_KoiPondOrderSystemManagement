using System;
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
    public class IndexModel : PageModel
    {
        //private readonly zPayment.Repositories.Models.FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext _context;
        private readonly OrderService _orderService;

        public IndexModel(OrderService orderService)
        {
            _orderService = orderService;
        }

        public IList<Order> Order { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchOrderId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchDescription { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchAddress { get; set; }

        public async Task OnGetAsync()
        {
            //Order = await _context.Orders
            //.Include(o => o.Customer)
            //.Include(o => o.Payment)
            //.Include(o => o.Promotion).ToListAsync();
            if (!string.IsNullOrEmpty(SearchOrderId) ||
            !string.IsNullOrEmpty(SearchDescription) ||
            !string.IsNullOrEmpty(SearchAddress))
            {
                Order = await _orderService.Search(SearchOrderId, SearchDescription, SearchAddress);
            }
            else
            {
                Order = await _orderService.GetAll();
            }

            ViewData["searchOrderId"] = SearchOrderId;
            ViewData["searchDescription"] = SearchDescription;
            ViewData["searchAddress"] = SearchAddress;
        }
    }
}
