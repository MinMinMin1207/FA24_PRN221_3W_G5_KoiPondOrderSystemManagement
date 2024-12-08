using KoiPondOrderSystemManagement.Repositories;
using KoiPondOrderSystemManagement.Repositories.DTOs;
using KoiPondOrderSystemManagement.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPondOrderSystemManagement.Services
{
    public class OrderPaymentService
    {
        private OrderPaymentRepository _orderPaymentRepository;

        public OrderPaymentService()
        {
            _orderPaymentRepository = new OrderPaymentRepository();
        }

        public async Task<List<Order>> GetPendingOrders()
        {
            return await _orderPaymentRepository.GetPendingOrderList();
        }

        public async Task<OrderDetailsModel> GetOrderDetails(int id)
        {
            return await _orderPaymentRepository.GetOrderDetails(id);
        }

        public async Task<Order> GetById(int id)
        {
            return await _orderPaymentRepository.GetByIdAsync(id);
        }

        public async Task<int> Update(Order order)
        {
            return await _orderPaymentRepository.UpdateAsync(order);
        }
    }
}
