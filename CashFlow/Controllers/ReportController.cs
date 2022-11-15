using CashFlow.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Controllers
{
    [Route("api/ReportController")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IFlowService flowService;

        public ReportController(IFlowService flowService)
        {
            this.flowService = flowService;
        }

        [HttpGet("GetDailyReport")]
        public IActionResult GetDailyReport()
        {
            return Ok(this.flowService.GetDailyReport());
        }
    }
}
