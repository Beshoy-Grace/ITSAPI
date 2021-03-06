using ITSFinalAPI.Errors;
using ITSFinalAPI.Intefaces;
using ITSFinalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSFinalAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemsController(IItemRepository itemRepository)
        {

            _itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Item>> GetItemById(int ItemId)
        {
            var itemFromDB = await _itemRepository.GetItemAsync(ItemId);

            if (itemFromDB == null)
                return new BadRequestObjectResult(new ApiValidationErrorResponse { Errors = new[] { "Bad Rquest, Item not found" } });

            return Ok(itemFromDB);
        }



        [HttpGet("AllItems")]
        public async Task<ActionResult<List<Item>>> GetAllItem()
        {
            var itemFromDB = await _itemRepository.GetAllItemAsync();

            return Ok(itemFromDB);
        }

        [HttpPost("AddItem")]
        public async Task<ActionResult<Item>> AddItem(Item item)
        {

            var itemFromDB = await _itemRepository.AddItemAsync(item);

            return Ok(itemFromDB);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Item>> UpdateItemAsync(Item item)
        {
            var itemFromDB = await _itemRepository.UpdateItemtAsync(item);
            if (itemFromDB == null)
                await _itemRepository.AddItemAsync(item);

            return Ok(itemFromDB);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> DeleteItemAsync(int itemId)
        {
            var itemFromDB = await _itemRepository.DeleteItemAsync(itemId);
            if (itemFromDB == false)
                return new BadRequestObjectResult(new ApiValidationErrorResponse { Errors = new[] { "Bad Rquest, Item not found" } });

            return Ok(itemFromDB);
        }


        [HttpDelete("DeleteAll")]
        public async Task<ActionResult<bool>> DeleteAllItemAsync(int stepId)
        {
            var itemSteps = await _itemRepository.GetAllItemAsync();
            foreach (var item in itemSteps.Where(x => x.Step == stepId))
            {
                var itemFromDB = await _itemRepository.DeleteItemAsync(item.Id);
            }



            return Ok();
        }

    }
}
