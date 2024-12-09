using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiPondOrderSystemManagement.Repositories.Models;
using KoiPondOrderSystemManagement.Services;
using X.PagedList;
using X.PagedList.Extensions;

namespace KoiPondOrderSystemManagement.RazorWebApp.Pages.Designs
{
    public class IndexModel : PageModel
    {
        private readonly DesignService _designService;

        public IndexModel(DesignService designService)
        {
            _designService = designService;
        }

        public IList<Design> Design { get; set; } = new List<Design>();

        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string SearchStyle { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string SearchDescription { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 5;

        public IPagedList<Design> PagedDesign { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var loginAccount = SessionHelper.GetLoginAccount(HttpContext.Session, "LoginAccount");

            if (loginAccount == null)
            {
                return Redirect("/Login");
            }

            if (!loginAccount.Role.Equals("Admin") && !loginAccount.Role.Equals("Manager"))
            {
                return StatusCode(403);
            }

            // Fetch data based on search criteria
            Design = await _designService.GetAll(SearchName, SearchStyle, SearchDescription);

            // Convert to paged list
            PagedDesign = Design.ToPagedList(PageNumber, PageSize);
            return Page();
        }
    }
}
