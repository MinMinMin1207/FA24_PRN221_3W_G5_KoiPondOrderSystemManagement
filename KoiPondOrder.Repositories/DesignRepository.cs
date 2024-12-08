using KoiPondOrder.Repositories;
using KoiPondOrderSystemManagement.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPondOrderSystemManagement.Repositories
{
    public class DesignRepository : GenericRepository<Design>
    {
        public DesignRepository() { }

        public async Task<List<Design>> GetAllAsync(string designName, string designStyle, string description)
        {
            var queryable = _context.Designs.AsQueryable();
            if (!string.IsNullOrEmpty(designName))
            {
                queryable = queryable.Where(f => f.DesignName.Contains(designName));
            }
            if (!string.IsNullOrEmpty(designStyle))
            {
                queryable = queryable.Where(f => f.DesignStyle.Contains(designStyle));
            }
            if (!string.IsNullOrEmpty(description))
            {
                queryable = queryable.Where(f => f.DesignStyle.Contains(description));
            }
            return queryable.ToList();
        }
    }
}
