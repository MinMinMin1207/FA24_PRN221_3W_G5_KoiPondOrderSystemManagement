﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiPondOrderSystemManagement.Services;
using KoiPondOrderSystemManagement.RazorWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using KoiPondOrder.Repositories.Models;

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
            var userRole = HttpContext.Session.GetString("UserRole");

           
            if (userRole != "Manager")
            {
                
                return RedirectToPage("/Index");
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
