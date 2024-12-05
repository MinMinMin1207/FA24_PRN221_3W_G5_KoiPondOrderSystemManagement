using KoiPondOrder.Repositories.Models;
using KoiPondOrderSystemManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPondOrderSystemManagement.Services
{
    public class PaymentService
    {
        private PaymentRepository _paymentRepository;

        public PaymentService()
        {
            _paymentRepository = new PaymentRepository();
        }

        public async Task<List<Payment>> GetAll()
        {
            return await _paymentRepository.GetAllAsync();
        }

        public async Task<int> Create(Payment payment)
        {
            return await _paymentRepository.CreateAsync(payment);
        }

        public async Task<Payment> GetById(int id)
        {
            return await _paymentRepository.GetByIdAsync(id);
        }

        public async Task<int> Update(Payment payment)
        {
            return await _paymentRepository.UpdateAsync(payment);
        }

        public async Task<bool> Delete(Payment payment)
        {
            return await _paymentRepository.RemoveAsync(payment);
        }
    }
}
