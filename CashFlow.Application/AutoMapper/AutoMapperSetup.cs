using AutoMapper;
using CashFlow.Application.ViewModels;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain
            CreateMap<FlowViewModel, Flow>();
            #endregion

            #region DomainToViewModel
            CreateMap<Flow, FlowViewModel>();
            #endregion
        }
    }
}
