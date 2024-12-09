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
    public class PondsRepository : GenericRepository<Pond>
    {
        private readonly FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext _context;
        public PondsRepository(FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Pond>> GetAllWithDetailsAsync()
        {
            return await _context.Ponds
                .Include(p => p.ConsultingStaff)
                .Include(p => p.Customer)
                .Include(p => p.Design)
                .Include(p => p.DesignStaff)
                .Include(p => p.Payment)
                .Include(p => p.Promotion)
                .ToListAsync();
        }
        public async Task<Pond> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Ponds
                .Include(p => p.ConsultingStaff)
                .Include(p => p.Customer)
                .Include(p => p.Design)
                .Include(p => p.DesignStaff)
                .Include(p => p.Payment)
                .Include(p => p.Promotion)
                .FirstOrDefaultAsync(p => p.PondId == id);
        }
        public async Task<List<Design>> GetAllDesigns()
        {
            return await _context.Designs.ToListAsync();
        }
        public async Task<List<Payment>> GetAllPayments()
        {
            return await _context.Payments.ToListAsync();
        }
        public async Task<List<Promotion>> GetAllPromotions()
        {
            return await _context.Promotions.ToListAsync();
        }

        public async Task<List<Pond>> SearchPond(string consultingStaff, string customer, string designStaff)
        {
            return await _context.Ponds
                .Include(p => p.ConsultingStaff)
                .Include(p => p.Customer)
                .Include(p => p.DesignStaff)
                .Include(p => p.Payment)
                .Include(p => p.Promotion)
                .Where(p =>
                    (string.IsNullOrEmpty(consultingStaff) || p.ConsultingStaff.FullName.Contains(consultingStaff)) &&
                    (string.IsNullOrEmpty(customer) || p.Customer.FullName.Contains(customer)) &&
                    ((string.IsNullOrEmpty(designStaff) || p.DesignStaff.FullName.Contains(designStaff))))
                .ToListAsync();
        }

        public async Task<List<Pond>> GetPondListByPaymentId(int id)
        {
            return await _context.Ponds.Where(p => p.PaymentId == id).ToListAsync();
        }
    }
}
