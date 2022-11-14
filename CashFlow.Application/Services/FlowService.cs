
using AutoMapper;
using CashFlow.Application.Interfaces;
using CashFlow.Application.ViewModels;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace CashFlow.Application.Services
{
    public class FlowService : IFlowService
    {
        private readonly IFlowRepository flowRepository;
        private readonly IMapper mapper;
        public FlowService(IFlowRepository flowRepository, IMapper mapper)
        {
            this.flowRepository = flowRepository;
            this.mapper = mapper;
        }
        public List<FlowViewModel> Get() 
        {
            List<FlowViewModel> _flowViewModels = new List<FlowViewModel>();
            IEnumerable<Flow> _flows = this.flowRepository.GetAll();

            _flowViewModels = mapper.Map<List<FlowViewModel>>(_flows);
            return _flowViewModels;
        }

        public bool Post(FlowViewModel flowViewModel)
        {
            if(flowViewModel.Id == Guid.Empty)
                throw new Exception("ID da transação não pode ser nula");

            Validator.ValidateObject(flowViewModel, new ValidationContext(flowViewModel), true);

            Flow _flow = mapper.Map<Flow>(flowViewModel);
            this.flowRepository.Create(_flow);

            return true;
        }

        public FlowViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid flowId))
                throw new Exception("Transação inválida");

            Flow _flow = this.flowRepository.Find(x => x.Id == flowId && !x.IsDeleted);
            if (_flow == null)
                throw new Exception("Transação não encontrada");

            return mapper.Map<FlowViewModel>(_flow);
        }

        public bool Put(FlowViewModel flowViewModel)
        {
            Flow _flow = this.flowRepository.Find(x => x.Id == flowViewModel.Id && !x.IsDeleted);
            if (_flow == null)
                throw new Exception("Transação não encontrada");

            _flow = mapper.Map<Flow>(flowViewModel);
            _flow.DateUpdated = DateTime.Now;
            this.flowRepository.Update(_flow);

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid flowId))
                throw new Exception("Transação inválida");

            Flow _flow = this.flowRepository.Find(x => x.Id == flowId && !x.IsDeleted);
            if (_flow == null)
                throw new Exception("Transação não encontrada");

            _flow.Id = flowId;
            _flow.DateUpdated = DateTime.Now;
            _flow.IsDeleted = true;
            this.flowRepository.Update(_flow);

            return true;
        }
    }
}
