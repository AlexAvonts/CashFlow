using CashFlow.Application.Interfaces;
using CashFlow.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    public class FlowController : ControllerBase
    {
        private readonly IFlowService flowService;

        public FlowController(IFlowService flowService)
        {
            this.flowService = flowService;
        }

        [HttpGet]
        public IActionResult Get()
        {            
            return Ok(this.flowService.Get());
        }

        [HttpPost]
        public IActionResult Post(FlowViewModel flowViewModel)
        {
            return Ok(this.flowService.Post(flowViewModel));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(this.flowService.GetById(id));
        }

        [HttpPut]
        public IActionResult Put(FlowViewModel flowViewModel)
        {
            return Ok(this.flowService.Put(flowViewModel));
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            return Ok(this.flowService.Delete(id));
        }
    }
}
