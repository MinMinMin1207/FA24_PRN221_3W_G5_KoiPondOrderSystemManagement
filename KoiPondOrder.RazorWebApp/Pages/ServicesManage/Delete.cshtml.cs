using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrder.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.ServicesManage
{
    public class DeleteModel : PageModel
    {
        private readonly ServicesService _servicesService;
        public DeleteModel(ServicesService servicesService)
        {
            _servicesService = servicesService;
           
        }

        [BindProperty]
        public Service Service { get; set; } = default!;

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

            var service = await _servicesService.GetById(id ?? default(int));

            if (service == null)
            {
                return NotFound();
            }
            else
            {
                Service = service;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _servicesService.GetById(id ?? default(int));
            if (service != null)
            {
                Service = service;
                _servicesService.Delete(service);
            }

            return RedirectToPage("./Index");
        }
    }
}
