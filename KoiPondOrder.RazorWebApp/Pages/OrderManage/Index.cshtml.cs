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
        private readonly OrderService _orderService;

        public IndexModel(OrderService orderService)
        {
            _orderService = orderService;
        }

        public Pagination<Order> OrderPagination { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchOrderId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchDescription { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchAddress { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        private const int PageSize = 10; 

        public async Task OnGetAsync()
        {
            var loginAccount = SessionHelper.GetLoginAccount(HttpContext.Session, "LoginAccount");      
            List<Order> orders;

            if (!string.IsNullOrEmpty(SearchOrderId) ||
                !string.IsNullOrEmpty(SearchDescription) ||
                !string.IsNullOrEmpty(SearchAddress))
            {
                orders = await _orderService.Search(SearchOrderId, SearchDescription, SearchAddress);
            }
            else
            {
                orders = await _orderService.GetAll();
            }

            OrderPagination = Pagination<Order>.Create(orders, PageNumber, PageSize);

            ViewData["searchOrderId"] = SearchOrderId;
            ViewData["searchDescription"] = SearchDescription;
            ViewData["searchAddress"] = SearchAddress;
        }
    }

}
