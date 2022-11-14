
using AutoMapper;
using CashFlow.Domain.Interfaces;

namespace CashFlow.Application.Services
{
    public class CreditFlowService : FlowService
    {
        public CreditFlowService(IFlowRepository flowRepository, IMapper mapper) : base(flowRepository, mapper)
        {
        }
    }
}
