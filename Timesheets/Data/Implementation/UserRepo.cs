using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly TimesheetDbContext _timesheetDbContext;

        public UserRepo(TimesheetDbContext timesheetDbContext)
        {
            _timesheetDbContext = timesheetDbContext;
        }

        public async Task<User> GetItem(Guid id)
        {
            var result = await _timesheetDbContext.Users.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<User>> GetItems()
        {
            var rawResult = await _timesheetDbContext.Users.ToListAsync();
            var result = rawResult;
            return result.AsEnumerable();
        }

        public async Task Add(User item)
        {
            await _timesheetDbContext.Users.AddAsync(item);
            await _timesheetDbContext.SaveChangesAsync();
        }

        public async Task Update(User item)
        {
            _timesheetDbContext.Users.Update(item);
            await _timesheetDbContext.SaveChangesAsync();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}