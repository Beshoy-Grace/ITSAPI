using ITSFinalAPI.Intefaces;
using ITSFinalAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSFinalAPI.Data.Infrastructure
{
    public class ItemRepository : IItemRepository
    {
        private readonly StoreContext _context;
        public ItemRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Item> AddItemAsync(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteItemAsync(int itemId)
        {
            var itemDB = await GetItemAsync(itemId);
            _context.Items.Remove(itemDB);

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<List<Item>> GetAllItemAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemAsync(int itemId)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.Id == itemId);
        }

        public async Task<Item> UpdateItemtAsync(Item item)
        {
            var itemDB = await GetItemAsync(item.Id);
            if (itemDB == null)
                return null;

            itemDB.Title = item.Title;
            itemDB.Description = item.Description;
            itemDB.Step = item.Step;
            await _context.SaveChangesAsync();

            return itemDB;

        }


    }
}
