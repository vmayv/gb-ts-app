﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SheetsController: ControllerBase
    {
        private readonly ISheetManager _sheetManager;
        private readonly IContractManager _contractManager;
        
        public SheetsController(ISheetManager sheetManager, IContractManager contractManager)
        {
            _sheetManager = sheetManager;
            _contractManager = contractManager;
        }

        [HttpGet("getOne")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _sheetManager.GetItem(id);
            
            return Ok(result);
        }
        
        [HttpGet("getAll")]
        public async Task<IActionResult> GetItems()
        {
            var result = await _sheetManager.GetItems();
            return Ok(result);
        }

        /// <summary> Возвращает запись табеля </summary>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] SheetRequest sheet)
        {
            var isAllowedToCreate = await _contractManager.CheckContractIsActive(sheet.ContractId);

            if (isAllowedToCreate !=null && !(bool)isAllowedToCreate)
            {
                return BadRequest($"Contract {sheet.ContractId} is not active or not found.");
            }
            
            var id = await _sheetManager.Create(sheet);
            return Ok(id);
        }

        /// <summary> Обновляет запись табеля </summary>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SheetRequest sheet)
        {
            var isAllowedToCreate = await _contractManager.CheckContractIsActive(sheet.ContractId);

            if (isAllowedToCreate !=null && !(bool)isAllowedToCreate)
            {
                return BadRequest($"Contract {sheet.ContractId} is not active or not found.");
            }

            await _sheetManager.Update(id, sheet);

            return Ok();
        }
    }
}