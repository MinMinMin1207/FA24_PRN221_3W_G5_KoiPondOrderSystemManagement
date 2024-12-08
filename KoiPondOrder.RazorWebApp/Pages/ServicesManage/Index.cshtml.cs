using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiPondOrderSystemManagement.RazorWebApp.Models;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrder.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.ServicesManage
{
    public class IndexModel : PageModel
    {
        private readonly ServicesService _servicesService;
        [BindProperty]
        public ServicesSearchModel SearchModel { get; set; }
        public IndexModel(ServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        public IList<Service> Service { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var userRole = HttpContext.Session.GetString("UserRole");

           
            if (userRole != "Manager")
            {
                return RedirectToPage("/Index");
            }

            
            Service = await _servicesService.GetServicesWithDetails();

            
            return Page();
        }
        public async Task OnPostSearchAsync()
        {
            Service = await _servicesService.SearchServices(SearchModel.Staff, SearchModel.Customer, SearchModel.PaymentMethod);
        }
    }
}
