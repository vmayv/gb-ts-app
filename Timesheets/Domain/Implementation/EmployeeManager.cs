using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Implementation
{
    public class EmployeeManager : IEmployeeManager
    {
        private IEmployeeRepo _employeeRepo;

        public EmployeeManager(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<Employee> GetItem(Guid id)
        {
            return await _employeeRepo.GetItem(id);
        }

        public async Task<IEnumerable<Employee>> GetItems()
        {
            return await _employeeRepo.GetItems();
        }

        public async Task<Guid> Create(EmployeeRequest employeeRequest)
        {
            var employee = new Employee()
            {
                Id = new Guid(),
                UserId = employeeRequest.UserId,
                IsDeleted = false
            };
            await _employeeRepo.Add(employee);
            return employee.Id;
        }

        public Task Update(Guid id, EmployeeRequest employeeRequest)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}