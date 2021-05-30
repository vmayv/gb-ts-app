using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class SheetRepo: ISheetRepo
    {
        private readonly TimesheetDbContext _timesheetDbContext;

        public SheetRepo(TimesheetDbContext Dbcontext)
        {
            _timesheetDbContext = Dbcontext;
        }

        public async Task<Sheet> GetItem(Guid id)
        {
            var result = await _timesheetDbContext.Sheets.FindAsync(id);

            return result;
        }

        public async Task<IEnumerable<Sheet>> GetItems()
        {
            var result =  await _timesheetDbContext.Sheets.ToListAsync();
            var filteredResult = result.Where(x => x.Amount > 2);


            var result2 = _timesheetDbContext.Sheets.AsQueryable();
            filteredResult = result2.Where(x => x.Amount > 2);

            return filteredResult.AsEnumerable();
        }

        public async Task Add(Sheet item)
        {
            await _timesheetDbContext.Sheets.AddAsync(item);
            await _timesheetDbContext.SaveChangesAsync();
        }

        public async Task Update(Sheet item)
        {
            _timesheetDbContext.Sheets.Update(item);
            await _timesheetDbContext.SaveChangesAsync();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}