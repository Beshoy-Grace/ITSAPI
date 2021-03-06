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
    public class StepsController : ControllerBase
   
    {
        private readonly IStepRepository _stepRepository;

        public StepsController(IStepRepository stepRepository)
        {

            _stepRepository = stepRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Step>> GetStepById(int StepId)
        {
            var itemFromDB = await _stepRepository.GetStepAsync(StepId);

            if (itemFromDB == null)
                return new BadRequestObjectResult(new ApiValidationErrorResponse { Errors = new[] { "Bad Rquest, Item not found" } });

            return Ok(itemFromDB);
        }

        [HttpPost("AddStep")]
        public async Task<ActionResult<Step>> AddItem()
        {
            var step = new Step();
            step.Title = "Step Number";
            var itemFromDB = await _stepRepository.AddStepAsync(step);

            return Ok(itemFromDB);
        }


        [HttpGet("AllSteps")]
        public async Task<ActionResult<List<Step>>> GetAllStep()
        {
            var itemFromDB = await _stepRepository.GetAllStepAsync();

            return Ok(itemFromDB);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> DeleteItemAsync(int stepId)
        {
            var itemFromDB = await _stepRepository.DeleteStepAsync(stepId);
            if (itemFromDB == false)
                return new BadRequestObjectResult(new ApiValidationErrorResponse { Errors = new[] { "Bad Rquest, Item not found" } });

            return Ok(itemFromDB);
        }
    }
}
