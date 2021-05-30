using Timesheets.Domain.Interfaces;

namespace Timesheets.Controllers
{
    public class EmployeesController
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeesController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
    }
}