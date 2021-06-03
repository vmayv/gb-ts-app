using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class EmployeeRepo:IEmployeeRepo
    {
        private readonly TimesheetDbContext _timesheetDbContext;

        public EmployeeRepo(TimesheetDbContext timesheetDbContext)
        {
            _timesheetDbContext = timesheetDbContext;
        }

        public async Task<Employee> GetItem(Guid id)
        {
            return await _timesheetDbContext.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetItems()
        {
            var rawResult = await _timesheetDbContext.Employees.ToListAsync();
            var result = rawResult.Where(x => !x.IsDeleted);
            return result.AsEnumerable();

        }

        public async Task Add(Employee item)
        {
            await _timesheetDbContext.Employees.AddAsync(item);
            await _timesheetDbContext.SaveChangesAsync();
        }

        public async Task Update(Employee item)
        {
            _timesheetDbContext.Employees.Update(item);
            await _timesheetDbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var item = await _timesheetDbContext.Employees.FindAsync(id);
            if (item != null)
            {
                item.IsDeleted = true;
                _timesheetDbContext.Employees.Update(item);
                await _timesheetDbContext.SaveChangesAsync();
            }
        }
    }
}

