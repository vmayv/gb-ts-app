using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        
        [HttpGet("getOne")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _userManager.GetItem(id);
            
            return Ok(result);
        }
        
        [HttpGet("getAll")]
        public async Task<IActionResult> GetItems()
        {
            var result = await _userManager.GetItems();
            return Ok(result);
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UserRequest user)
        {
            var id = await _userManager.Create(user);
            return Ok(id);
        }
        
        [HttpPut("update")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserRequest user)
        {

            return Ok();
        }
    }
}