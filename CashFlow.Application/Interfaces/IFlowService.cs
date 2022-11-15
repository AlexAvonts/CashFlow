
using CashFlow.Application.ViewModels;
using System.Collections.Generic;

namespace CashFlow.Application.Interfaces
{
    public interface IFlowService
    {
        List<FlowViewModel> Get();
        bool Post(FlowViewModel flowViewModel);
        FlowViewModel GetById(string id);
        bool Put(FlowViewModel flowViewModel);
        bool Delete(string id);
        List<ReportFlowViewModel> GetDailyReport();
    }
}
