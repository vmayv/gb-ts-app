using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class ClientRepo: IClientRepo
    {
        private readonly TimesheetDbContext _timesheetDbContext;

        public ClientRepo(TimesheetDbContext timesheetDbContext)
        {
            _timesheetDbContext = timesheetDbContext;
        }

        public async Task<Client> GetItem(Guid id)
        {
            return await _timesheetDbContext.Clients.FindAsync(id);
        }

        public async Task<IEnumerable<Client>> GetItems()
        {
            var rawResult = await _timesheetDbContext.Clients.ToListAsync();
            var result = rawResult.Where(x => !x.IsDeleted);
            return result.AsEnumerable();
        }

        public async Task Add(Client item)
        {
            await _timesheetDbContext.Clients.AddAsync(item);
            await _timesheetDbContext.SaveChangesAsync();
        }

        public async Task Update(Client item)
        {
            _timesheetDbContext.Clients.Update(item);
            await _timesheetDbContext.SaveChangesAsync();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}