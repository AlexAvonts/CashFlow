
using AutoMapper;
using CashFlow.Application.Interfaces;
using CashFlow.Application.ViewModels;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
            IEnumerable<Flow> _flows = this.flowRepository.GetAll();
            return mapper.Map<List<FlowViewModel>>(_flows); ;
        }

        public bool Post(FlowViewModel flowViewModel)
        {
            if(flowViewModel.Id == Guid.Empty)
                throw new Exception("ID da transação não pode ser nulo");

            Validator.ValidateObject(flowViewModel, new ValidationContext(flowViewModel), true);

            Flow _flow = mapper.Map<Flow>(flowViewModel);
            _flow.DateCreated = DateTime.Now;
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

        public List<ReportFlowViewModel> GetDailyReport()
        {
            IEnumerable<Flow> flows= this.flowRepository.GetAll();

            IEnumerable<IGrouping<DateTime, Flow>> _flows = flowRepository.GetAll().GroupBy(x => x.DateCreated.Date).ToList();

            if (_flows == null)
                throw new Exception("Não foi possível obter o fluxo do caixa.");

            IEnumerable<ReportFlow> reportFlows = this.SumByDay(_flows);
            return mapper.Map<List<ReportFlowViewModel>>(reportFlows);
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

        private List<ReportFlow> SumByDay(IEnumerable<IGrouping<DateTime, Flow>> flows)
        {
            List<ReportFlow> _flows = new List<ReportFlow>();

            var credits = flows.Select(x => x.Where(a => a.FlowType == "c")).ToList();
            var creditsValues = credits.Select(x => x.Select(a => a.Value).Sum()).ToList();

            var debits = flows.Select(x => x.Where(a => a.FlowType == "d")).ToList();
            var debitsValues = debits.Select(x => x.Select(a => a.Value).Sum()).ToList();

            int aux = 0;

            foreach (var items in flows)
            {
                ReportFlow _flow = new ReportFlow();

                _flow.SumValue = (creditsValues[aux] - debitsValues[aux]).ToString("C2");
                _flow.Date = items.Key.ToShortDateString();
                _flows.Add(_flow);
                aux++;
            }

            return _flows;
        }       
    }
}
