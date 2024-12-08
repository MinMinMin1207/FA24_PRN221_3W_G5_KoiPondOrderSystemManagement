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

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.ServicesManage
{
    public class EditModel : PageModel
    {
        private readonly ServicesService _servicesService;
        public EditModel(ServicesService servicesService)
        {
            _servicesService = servicesService;          
        }

        [BindProperty]
        public Service Service { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // if (id == null)
            // {
            //     return NotFound();
            // }

            // var service =  await _context.Services.FirstOrDefaultAsync(m => m.ServiceId == id);
            // if (service == null)
            // {
            //     return NotFound();
            // }
            // Service = service;
            //ViewData["CustomerId"] = new SelectList(_context.Users, "UserId", "Email");
            //ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "PaymentMethod");
            //ViewData["PromotionId"] = new SelectList(_context.Promotions, "PromotionId", "PromotionName");
            //ViewData["StaffId"] = new SelectList(_context.Users, "UserId", "Email");
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

            var service = await _servicesService.GetById(id.Value);
            if (service == null)
            {
                return NotFound();
            }
            Service = service;
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
                await _servicesService.Update(Service);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(Service.ServiceId))
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

        private bool ServiceExists(int id)
        {
            var result = _servicesService.GetById(id);
            if (result == null)
            {
                return false;
            }
            return true;
        }
    }
}
