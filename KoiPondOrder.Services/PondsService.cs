
using KoiPondOrderSystemManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiPondOrderSystemManagement.Repositories.Models;

namespace KoiPondOrderSystemManagement.Services
{
    public class PondsService
    {

        private readonly PondsRepository _pondsRepository;

        public PondsService(PondsRepository pondsRepository)
        {
            _pondsRepository = pondsRepository;
        }

        public async Task<List<Pond>> GetAllWithDetails()
        {
            return await _pondsRepository.GetAllWithDetailsAsync();
        }

        public async Task<Pond> GetByIdWithDetails(int id)
        {
            return await _pondsRepository.GetByIdWithDetailsAsync(id);
        }

        public async Task<List<Pond>> GetAll()
        {
            return await _pondsRepository.GetAllAsync();
        }
        public async Task<List<Design>> GetAllDesigns()
        {
            return await _pondsRepository.GetAllDesigns();
        }
        public async Task<List<Payment>> GetAllPayments()
        {
            return await _pondsRepository.GetAllPayments();
        }
        public async Task<List<Promotion>> GetAllPromotions()
        {
            return await _pondsRepository.GetAllPromotions();
        }
        public async Task<List<Pond>> SearchPond(string consultingStaff, string customer, string designStaff)
        {
            return await _pondsRepository.SearchPond(consultingStaff, customer, designStaff);
        }
        public async Task<int> Create(Pond pond)
        {
            return await _pondsRepository.CreateAsync(pond);
        }

        public async Task<Pond> GetById(int id)
        {
            return await _pondsRepository.GetByIdAsync(id);
        }

        public async Task<int> Update(Pond pond)
        {
            return await _pondsRepository.UpdateAsync(pond);
        }

        public async Task<bool> Delete(Pond pond)
        {
            return await _pondsRepository.RemoveAsync(pond);
        }


    }
}
