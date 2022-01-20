using ApplicationLayer.Interfaces;
using DataAccess.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIInventoryMgt.Commands.InventoryCommand.DeleteCommand;
using WebAPIInventoryMgt.Commands.InventoryCommand.GetByIdCommand;
using WebAPIInventoryMgt.Commands.InventoryCommand.UpdateCommand;
using WebAPIInventoryMgt.Handler.InventoryCommand;

namespace WebAPIInventoryMgt.Controllers
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryAppService _inventoryService;

        private IMediator _mediator;
        public InventoryController(IInventoryAppService inventoryService,
            IMediator mediator)
        {
            this._inventoryService = inventoryService;
            this._mediator = mediator;
        }

        [HttpGet("getInventoryList")]
        public async Task<IActionResult> Get()
        {
            var result = await _inventoryService.GetInventoryList();
            return Ok(result);
        }

        [HttpGet("getInventoryById/{id}")]
        public async Task<IActionResult> GetInventoryById(int id)
        {
            var result = await _inventoryService.GetInventoryById(id);
            return Ok(result);
        }

        [HttpPost("saveInventory")]
        public async Task<IActionResult> SaveInventory([FromBody] AddInventoryModel inventory)
        {
            //_ _mediator.Send will call AddCountryCommandHandler from Commands folder
            var result = await _mediator.Send(inventory);
            return Ok(result);
        }

        [HttpPut("updateInventory")]
        public async Task<IActionResult> UpdateInventory([FromBody] UpdateInventoryModel inventory)
        {
            //_ _mediator.Send will call UpdateCountryCommandHandler from Commands folder
            var result = await _mediator.Send(inventory);
            return Ok(result);
        }

        //[HttpDelete("deleteInventory/{InventoryId}")]
        [HttpDelete("deleteInventory")]
        public async Task<IActionResult> DeleteInventory(DeleteInventoryModel inventoryModel)
        {
            //_ _mediator.Send will call DeleteCountryCommandHandler from Commands folder
            var result = await _mediator.Send(inventoryModel);
            return Ok(result);
        }


        //[HttpGet("getInventoryList")]
        //public async Task<IActionResult> Get()
        //{
        //    var result = await _inventoryService.GetInventoryList();
        //    return Ok(result);
        //}

        //[HttpGet("getInventoryById/{id}")]
        //public async Task<IActionResult> GetInventoryById(int id)
        //{
        //    var result = await _inventoryService.GetInventoryById(id);
        //    return Ok(result);
        //}

        //[HttpPost("saveInventory")]
        //public async Task<IActionResult> SaveEmployee([FromBody] Inventory inventory)
        //{
        //    var result = await _inventoryService.AddInventory(inventory);
        //    return Ok(result);
        //}

        //[HttpPut("updateInventory")]
        //public async Task<IActionResult> UpdateInventory([FromBody] Inventory inventory)
        //{
        //    var result = await _inventoryService.UpdateInventory(inventory);
        //    return Ok(result);
        //}

        //[HttpGet("checkDuplicateRecord/{name}")]
        //public async Task<IActionResult> CheckDuplicateRecord(string name)
        //{
        //    var inventoryList = await _inventoryService.GetInventoryByExpression(x => x.Name.ToLower() == name);

        //    if(inventoryList.Count() > 0) {
        //        //exist
        //        return Ok(true);
        //    }
        //    else
        //    {
        //        //not exist
        //        return Ok(false);
        //    }
        //}

        //[HttpDelete("deleteEmployee/{id}")]
        //public async Task<IActionResult> DeleteEmployee(int id)
        //{
        //    var result = await _employeeService.DeleteEmployee(id);
        //    return Ok(result);
        //}

    }
}
