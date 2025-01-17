﻿using System;
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
        private readonly TimesheetDbContext _context;

        public SheetRepo(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<Sheet> GetItem(Guid id)
        {
            var result = await _context.Sheets.FindAsync(id);

            return result;
        }

        public async Task<IEnumerable<Sheet>> GetItems()
        {
            var result =  await _context.Sheets.ToListAsync();
            var filteredResult = result.Where(x => x.Amount > 2);


            var result2 = _context.Sheets.AsQueryable();
            filteredResult = result2.Where(x => x.Amount > 2);

            return filteredResult.AsEnumerable();
        }

        public async Task Add(Sheet item)
        {
            await _context.Sheets.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Sheet item)
        {
            _context.Sheets.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}