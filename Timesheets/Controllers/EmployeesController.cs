using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeesController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        
        [HttpGet("getOne")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _employeeManager.GetItem(id);
            
            return Ok(result);
        }
        
        [HttpGet("getAll")]
        public async Task<IActionResult> GetItems()
        {
            var result = await _employeeManager.GetItems();
            return Ok(result);
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] EmployeeRequest employee)
        {
            var id = await _employeeManager.Create(employee);
            return Ok(id);
        }
        
        [HttpPut("update")]
        public async Task<IActionResult> Update(Guid id, [FromBody] EmployeeRequest employee)
        {
            await _employeeManager.Update(id, employee);
            return Ok();
        }
        
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _employeeManager.Delete(id);
            return Ok();
        }
    }
}