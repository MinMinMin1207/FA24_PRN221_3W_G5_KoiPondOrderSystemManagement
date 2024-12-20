﻿using KoiPondOrderSystemManagement.Repositories;
using KoiPondOrderSystemManagement.Repositories.DTOs;
using KoiPondOrderSystemManagement.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPondOrderSystemManagement.Services
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }
       
        public async Task<List<User>> GetAllCustomer()
        {
            return await _userRepository.GetAllCustomers();
        }

        public async Task<List<User>> GetAllConsultingStaff()
        {
            return await _userRepository.GetAllConsultingStaff();
        }

        public async Task<List<User>> GetAllConstructionStaff()
        {
            return await _userRepository.GetAllConstructionStaff();
        }

        public async Task<List<User>> GetAllDesignStaff()
        {
            return await _userRepository.GetAllDesignStaff();
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<int> Create(User user)
        {
            return await _userRepository.CreateAsync(user);
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<int> Update(User user)
        {
            return await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> Delete(User user)
        {
            return await _userRepository.RemoveAsync(user);
        }

        public List<User> Search(UserSearchModel? model)
        {
            return _userRepository.Search(model);
        }

        public User? Login(LoginRequestModel loginRequest)
        {
            return _userRepository.Login(loginRequest);
        }

        public async Task<bool> CheckIfExistedEmail(string email)
        {
            return await _userRepository.CheckIfExistedEmail(email);
        }
    }
}
