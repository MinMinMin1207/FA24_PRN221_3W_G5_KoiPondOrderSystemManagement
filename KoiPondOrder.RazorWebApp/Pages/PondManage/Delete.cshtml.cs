using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using KoiPondOrderSystemManagement.Services;
using KoiPondOrder.Repositories.Models;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.PondManage
{
    public class DeleteModel : PageModel
    {
        private readonly PondsService _pondsService;

        public DeleteModel(PondsService pondsService)
        {
            _pondsService = pondsService;
        }

        [BindProperty]
        public Pond Pond { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pond = await _pondsService.GetById(id ?? default(int));

            if (pond == null)
            {
                return NotFound();
            }
            else
            {
                Pond = pond;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pond = await _pondsService.GetById(id ?? default(int));
            if (pond != null)
            {
                Pond = pond;
                _pondsService.Delete(pond);
            }

            return RedirectToPage("./Index");
        }
    }
}
