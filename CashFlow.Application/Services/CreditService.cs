using AutoMapper;
using CashFlow.Application.Interfaces;
using CashFlow.Application.ViewModels;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using System;

namespace CashFlow.Application.Services
{
    public class CreditService : ICreditService
    {
        private readonly IMapper mapper;
        private readonly IFlowRepository flowRepository;
        public CreditService(IFlowRepository flowRepository, IMapper mapper) 
        {
            this.flowRepository = flowRepository;
            this.mapper = mapper;
        }

        public void AddCredit(FlowViewModel flowViewModel)
        {         
            FlowService flowService = new FlowService(flowRepository, mapper);
            Flow _flow = mapper.Map<Flow>(flowViewModel);

            _flow.Id = Guid.NewGuid();
            _flow.FlowType = flowViewModel.FlowType.ToUpper();
            _flow.DateCreated = DateTime.Now;
            flowService.Post(_flow);
        }
    }
}
