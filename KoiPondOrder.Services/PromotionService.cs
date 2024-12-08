using KoiPondOrderSystemManagement.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using KoiPondOrderSystemManagement.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KoiPondOrderSystemManagement.Repositories.PromotionRepository;


namespace KoiPondOrderSystemManagement.Services
{
    public class PromotionService
    {
        private readonly PromotionRepository _repository;

        public PromotionService()
        {
            _repository = new PromotionRepository();
        }
        public async Task<List<Promotion>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<int> Create(Promotion categoryBankAccount)
        {
            return await _repository.CreateAsync(categoryBankAccount);
        }

        public async Task<Promotion> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<int> Update(Promotion categoryBankAccount)
        {
            return await _repository.UpdateAsync(categoryBankAccount);
        }

        public async Task<bool> Delete(Promotion categoryBankAccount)
        {
            return await _repository.RemoveAsync(categoryBankAccount);
        }

        public async Task<PromotionResponse> GetListPaging(
string searchTerm,
int? pointsRequired,
decimal? discountPercentage,
int pageIndex,
int pageSize)
        {
            return await _repository.GetListPaging(searchTerm, pointsRequired, discountPercentage, pageIndex, pageSize);
        }
    }
}
