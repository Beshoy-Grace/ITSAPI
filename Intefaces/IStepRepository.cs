using ITSFinalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSFinalAPI.Intefaces
{
  public  interface IStepRepository
    {
        Task<List<Step>> GetAllStepAsync();
        Task<Step> GetStepAsync(int stepId);
        Task<Step> AddStepAsync(Step step);

        Task<bool> DeleteStepAsync(int stepId);
    }
}
