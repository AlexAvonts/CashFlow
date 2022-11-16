
using CashFlow.Application.ViewModels;
using CashFlow.Domain.Entities;
using System.Collections.Generic;

namespace CashFlow.Application.Interfaces
{
    public interface IFlowService
    {
        List<FlowViewModel> Get();
        bool Post(Flow flow);
        FlowViewModel GetById(string id);
        bool Put(FlowViewModel flowViewModel);
        bool Delete(string id);
        List<ReportFlowViewModel> GetDailyReport();
        bool FlowValidate(FlowViewModel flowViewModel);
    }
}
