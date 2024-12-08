using KoiPondOrderSystemManagement.Repositories;
using KoiPondOrderSystemManagement.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPondOrderSystemManagement.Services
{
    public class PromotionService
    {
        private PromotionRepository _repository;
        public PromotionService()
        {
            _repository ??= new PromotionRepository();
        }
        public PromotionService(PromotionRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Promotion>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<int> Create(Promotion categoryBankAccount)
        {
            return await _repository.CreateAsync(categoryBankAccount);
        }

        public async Task<Promotion> GetById(string id)
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

        //public List<CategoryBankAccount> Search(string bankNo, string holderName, string holderTaxCode)
        //{
        //    return _repository.Search(bankNo, holderName, holderTaxCode);
        //}
    }
}
