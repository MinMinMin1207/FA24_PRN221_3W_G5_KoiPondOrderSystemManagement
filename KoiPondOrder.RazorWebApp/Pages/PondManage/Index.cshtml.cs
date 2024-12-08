using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrderSystemManagement.RazorWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using KoiPondOrderSystemManagement.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.PondManage
{
 
    public class IndexModel : PageModel
    {
        
        private readonly PondsService _pondsService;
        [BindProperty]
        public PondSearchModel SearchModel { get; set; }
        public IndexModel(PondsService pondsService)
        {
            _pondsService = pondsService;
        }
        public IList<Pond> Pond { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
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




            Pond = await _pondsService.GetAllWithDetails();
            return Page();

        }
        public async Task OnPostSearchAsync()
        {
            Pond = await _pondsService.SearchPond( SearchModel.ConsultingStaff, SearchModel.Customer, SearchModel.DesignStaff);
        }
        
    }
}
