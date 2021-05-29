using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Implementation
{
    public class UserManager : IUserManager
    {
        private IUserRepo _userRepo;

        public UserManager(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> GetItem(Guid id)
        {
            return await _userRepo.GetItem(id);
        }

        public async Task<IEnumerable<User>> GetItems()
        {
            return await _userRepo.GetItems();
        }

        public async Task<Guid> Create(UserRequest userRequest)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Username = userRequest.Username
            };
            
            await _userRepo.Add(user);
            
            return user.Id;
        }

        public Task Update(Guid id, UserRequest userRequest)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}