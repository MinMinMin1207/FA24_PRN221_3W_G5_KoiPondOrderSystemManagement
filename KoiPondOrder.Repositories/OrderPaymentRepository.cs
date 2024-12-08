using KoiPondOrder.Repositories;
using KoiPondOrderSystemManagement.Repositories.DTOs;
using KoiPondOrderSystemManagement.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPondOrderSystemManagement.Repositories
{
    public class OrderPaymentRepository : GenericRepository<Order>
    {
        public OrderPaymentRepository()
        {

        }

        public async Task<List<Order>> GetPendingOrderList()
        {
            try
            {
                var _context = new FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext();
                var orderList = await _context.Orders.Where(o => o.OrderStatus.Equals("Pending") && !o.PaymentId.HasValue).ToListAsync();
                return orderList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderDetailsModel> GetOrderDetails(int id)
        {
            try
            {
                var _context = new FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext();
                var order = await _context.Orders.Where(o => o.OrderId == id).SingleOrDefaultAsync();
                var amount = order.FinalCost;
                var tax = order.FinalCost * 1 / 10;
                var discount = order.TotalCost - order.FinalCost;

                return new OrderDetailsModel
                {
                    Amount = amount,
                    Tax = tax,
                    Discount = discount,
                    FinalAmount = amount + tax,
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
