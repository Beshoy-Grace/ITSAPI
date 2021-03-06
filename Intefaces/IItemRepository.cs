using ITSFinalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSFinalAPI.Intefaces
{
   public interface IItemRepository
    {
        Task<Item> GetItemAsync(int itemId);
        Task<Item> AddItemAsync(Item item);
        Task<List<Item>> GetAllItemAsync();
        Task<Item> UpdateItemtAsync(Item item);
        Task<bool> DeleteItemAsync(int itemId);
    }
}
