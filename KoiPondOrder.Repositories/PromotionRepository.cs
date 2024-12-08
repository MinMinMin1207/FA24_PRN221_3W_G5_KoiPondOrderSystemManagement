using KoiPondOrder.Repositories;
using Microsoft.EntityFrameworkCore;
using KoiPondOrderSystemManagement.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPondOrderSystemManagement.Repositories
{
    public class PromotionRepository : GenericRepository<Promotion>
    {
        public PromotionRepository() { }

        public class PromotionResponse
        {
            public List<Promotion> Promotions { get; set; }

            public int TotalPages { get; set; }

            public int PageIndex { get; set; }
        }

        public async Task<PromotionResponse> GetListPaging(
        string searchTerm,
        int? pointsRequired,
        decimal? discountPercentage,
        int pageIndex,
        int pageSize)
        {

            var query = _context.Promotions.AsQueryable();

            // Search by PromotionName
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.PromotionName.ToLower().Contains(searchTerm.ToLower()));
            }

            // Search by PointsRequired
            if (pointsRequired.HasValue)
            {
                query = query.Where(x => x.PointsRequired == pointsRequired.Value);
            }

            // Search by DiscountPercentage
            if (discountPercentage.HasValue)
            {
                query = query.Where(x => x.DiscountPercentage == discountPercentage.Value);
            }

            int count = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(count / (double)pageSize);

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return new PromotionResponse
            {
                Promotions = await query.ToListAsync(),
                TotalPages = totalPages,
                PageIndex = pageIndex,
            };
        }
    }
}
