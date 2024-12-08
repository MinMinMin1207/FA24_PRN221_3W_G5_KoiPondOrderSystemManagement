using KoiPondOrderSystemManagement.Repositories;
using KoiPondOrderSystemManagement.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPondOrderSystemManagement.Services
{
    public class DesignService
    {
        private readonly DesignRepository _repository;

        public DesignService(DesignRepository repository)
        {
            _repository = repository;
        }

        public DesignService()
        {
            _repository = new DesignRepository();
        }

        public async Task<List<Design>> GetAll(string designName, string designStyle, string description)
        {
            return await _repository.GetAllAsync(designName, designStyle, description);
        }

        public async Task<int> Create(Design categoryBankAccount)
        {
            return await _repository.CreateAsync(categoryBankAccount);
        }

        public async Task<Design> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<int> Update(Design categoryBankAccount)
        {
            return await _repository.UpdateAsync(categoryBankAccount);
        }

        public async Task<bool> Delete(Design categoryBankAccount)
        {
            return await _repository.RemoveAsync(categoryBankAccount);
        }

        //public async Task<List<Design>> Search(string designName, string designStyle, int popularityScore)
        //{
        //    return await _repository.GetAllAsync(designName, designStyle, popularityScore);
        //}
    }
}
