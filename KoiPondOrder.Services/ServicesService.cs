
using KoiPondOrderSystemManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiPondOrderSystemManagement.Repositories.Models;

namespace KoiPondOrderSystemManagement.Services
{
    public class ServicesService
    {
        private ServicesRepository _servicesRepository;

        public ServicesService()
        {
            _servicesRepository = new ServicesRepository();
        }

        public async Task<List<Service>> GetAll()
        {
            return await _servicesRepository.GetAllAsync();
        }

        public async Task<int> Create(Service service)
        {
            return await _servicesRepository.CreateAsync(service);
        }

        public async Task<Service> GetById(int id)
        {
            return await _servicesRepository.GetByIdAsync(id);
        }

        public async Task<int> Update(Service service)
        {
            return await _servicesRepository.UpdateAsync(service);
        }

        public async Task<bool> Delete(Service service)
        {
            return await _servicesRepository.RemoveAsync(service);
        }
        public async Task<Service> GetByIdWithDetails(int id)
        {
            return await _servicesRepository.GetByIdWithDetailsAsync(id);
        }
        //public async Task<List<Service>> GetAllWithDetails()
        //{
        //    return await _servicesRepository.GetAllWithDetailsAsync();
        //}
        public async Task<List<Service>> GetServicesWithDetails()
        {
            return await _servicesRepository.GetAllService();
        }
        public async Task<List<Service>> SearchServices(string staff, string customer, string payment)
        {
            return await _servicesRepository.SearchServices(staff, customer, payment);
        }
    }
}
