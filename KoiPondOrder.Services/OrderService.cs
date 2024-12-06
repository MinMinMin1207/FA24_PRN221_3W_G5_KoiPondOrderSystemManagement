using KoiPondOrderSystemManagement.Repositories;
using KoiPondOrder.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KoiPondOrderSystemManagement.Services
{
    public class OrderService
    {
        private OrderRepository _repository;
        public OrderService()
        {
            _repository = new OrderRepository();
        }

        public async Task<List<Order>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<int> Create(Order order)
        {
            return await _repository.CreateAsync(order);
        }

        public async Task<Order> GetById(string id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<Order> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<int> Update(Order order)
        {
            return await _repository.UpdateAsync(order);
        }

        public async Task<bool> Delete(Order order)
        {
            return await _repository.RemoveAsync(order);
        }
        public async Task<List<Order>> Search(string? orderId, string? description, string? address)
        {
            return await _repository.SearchAsync(orderId, description, address);
        }
        //public List<CategoryBankAccount> Search(string bankNo, string holderName, string holderTaxCode)
        //{
        //    return _repository.Search(bankNo, holderName, holderTaxCode);
        //}
    }
}
