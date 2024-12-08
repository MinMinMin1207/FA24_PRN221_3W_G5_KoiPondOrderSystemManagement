using KoiPondOrder.Repositories;
using KoiPondOrder.Repositories.Models;
using KoiPondOrderSystemManagement.Repositories.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPondOrderSystemManagement.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        private static UserRepository instance = null;
        public UserRepository() { }
        public static UserRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new UserRepository();
            }
            return instance;
        }
        public List<User> Search(UserSearchModel? model)
        {
            try
            {
                using var _context = new FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext();
                var listUser = _context.Users.ToList().AsEnumerable();
                if (model != null)
                {
                    if (model.FullName != null)
                    {
                        listUser = listUser.Where(u => u.FullName.ToLower().Contains(model.FullName.ToLower()));
                    }

                    if (model.Email != null)
                    {
                        listUser = listUser.Where(u => u.Email.ToLower().Contains(model.Email.ToLower()));
                    }

                    if (model.Address != null)
                    {
                        listUser = listUser.Where(u => u.Address.ToLower().Contains(model.Address.ToLower()));
                    }
                }
                return listUser.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<User>> GetAllCustomers()
        {
            return await _context.Users.Where(u => u.Role == "Customer").ToListAsync();
        }
        public async Task<List<User>> GetAllConsultingStaff()
        {
            return await _context.Users.Where(u => u.Role == "ConsultingStaff").ToListAsync();
        }
        public async Task<List<User>> GetAllDesignStaff()
        {
            return await _context.Users.Where(u => u.Role == "DesignStaff").ToListAsync();
        }
        public async Task<List<User>> GetAllConstructionStaff()
        {
            return await _context.Users.Where(u => u.Role == "ConstructionStaff").ToListAsync();
        }
        public User Checklogin(string email, string password)
        {
            var u = new User();
            try
            {
                using (var db = new FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext())
                {
                    u = db.Users.FirstOrDefault(x => x.Email.Equals(email) && x.PasswordHash.Equals(password));
                    return u;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CheckIfExistedEmail(string email)
        {
            try
            {
                using var _context = new FA24_PRN221_3W_G5_KoiPondOrderSystemManagementContext();
                var mailList = await _context.Users.Select(u => u.Email.ToLower()).ToListAsync();
                if (mailList.Contains(email.ToLower()))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
