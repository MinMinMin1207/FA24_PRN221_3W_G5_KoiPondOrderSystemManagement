using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiPondOrder.Repositories;
using KoiPondOrderSystemManagement.Repositories.Models;

namespace KoiPondOrderSystemManagement.Repositories
{
    public class OrderRepository:GenericRepository<Order>
    {
        public OrderRepository() { }
        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Customer)     
                .Include(o => o.Payment)      
                .Include(o => o.Promotion)    
                .ToListAsync();
        }
        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Customer)  
                .Include(o => o.Payment)      
                .Include(o => o.Promotion)   
                .FirstOrDefaultAsync(o => o.OrderId == id); 
        }
        public async Task<List<Order>> SearchAsync(string? orderId, string? description, string? address)
        {
            var query = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Payment)
                .Include(o => o.Promotion)
                .AsQueryable();

            if (!string.IsNullOrEmpty(orderId))
                query = query.Where(o => o.OrderId.ToString().Contains(orderId));

            if (!string.IsNullOrEmpty(description))
                query = query.Where(o => o.OrderDescription.Contains(description));

            if (!string.IsNullOrEmpty(address))
                query = query.Where(o => o.DeliveryAddress.Contains(address));

            return await query.ToListAsync();
        }

    }
}
