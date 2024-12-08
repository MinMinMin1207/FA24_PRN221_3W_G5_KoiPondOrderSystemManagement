using KoiPondOrder.Repositories;
using KoiPondOrder.Repositories.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPondOrderSystemManagement.Repositories
{
    public class ServicesRepository :  GenericRepository<Service>
    {
        private readonly FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext _context;
        public ServicesRepository(FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext context)
        {
            _context = context;
        }
        public ServicesRepository()
        {

            _context ??= new FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext();
        }

        public async Task<List<Service>> GetAllService()
        {
            return await _context.Services
                .Include(s => s.Customer)
                .Include(s => s.Payment)
                .Include(s => s.Promotion)
                .Include(s => s.Staff)
                .ToListAsync();
        }
        public async Task<Service> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Services              
                .Include(p => p.Customer)               
                .Include(p => p.Staff)
                .Include(p => p.Payment)
                .Include(p => p.Promotion)
                .FirstOrDefaultAsync(p => p.ServiceId == id);
        }
       
        public async Task<List<Service>> SearchServices(string staff, string customer, string payment)
        {
            return await _context.Services
                .Include(p => p.Staff)
                .Include(p => p.Customer)
                .Include(p => p.Payment)
                .Include(p => p.Promotion)
                .Where(p =>
                    (string.IsNullOrEmpty(staff) || p.Staff.FullName.Contains(staff)) &&
                    (string.IsNullOrEmpty(customer) || p.Customer.FullName.Contains(customer)) &&
                    ((string.IsNullOrEmpty(payment) || p.Payment.PaymentMethod.Contains(payment))))
                .ToListAsync();
        }
    }
}
