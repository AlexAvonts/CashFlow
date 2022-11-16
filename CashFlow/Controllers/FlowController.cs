using CashFlow.Application.Interfaces;
using CashFlow.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace CashFlow.Controllers
{
    [Route("api/FlowController")]
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
            return Ok(this.flowService.FlowValidate(flowViewModel));
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
