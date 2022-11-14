
using AutoMapper;
using CashFlow.Domain.Interfaces;

namespace CashFlow.Application.Services
{
    public class DebitFlowService : FlowService
    {
        public DebitFlowService(IFlowRepository flowRepository, IMapper mapper) : base(flowRepository, mapper)
        {
        }
    }
}
