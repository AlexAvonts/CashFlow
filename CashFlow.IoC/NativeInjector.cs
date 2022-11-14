
using CashFlow.Application.Interfaces;
using CashFlow.Application.Services;
using CashFlow.Data.Repositories;
using CashFlow.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services) 
        {
            #region Services
            services.AddScoped<IFlowService, FlowService>();
            #endregion

            #region Repositories
            services.AddScoped<IFlowRepository, FlowRepository>();
            #endregion


        }
    }
}
