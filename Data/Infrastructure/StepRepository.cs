using ITSFinalAPI.Intefaces;
using ITSFinalAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSFinalAPI.Data.Infrastructure
{
    public class StepRepository : IStepRepository
    {
        private readonly StoreContext _context;
        public StepRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Step> AddStepAsync(Step step)
        {
            await _context.Steps.AddAsync(step);
            await _context.SaveChangesAsync();
            return step;
        }

        public async Task<bool> DeleteStepAsync(int stepId)
        {
            var itemDB = await GetStepAsync(stepId);
            _context.Steps.Remove(itemDB);

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<List<Step>> GetAllStepAsync()
        {
            return await _context.Steps.ToListAsync();
        }

        public async Task<Step> GetStepAsync(int stepId)
        {
            return await _context.Steps.FirstOrDefaultAsync(i => i.Id == stepId);
        }
    }
}