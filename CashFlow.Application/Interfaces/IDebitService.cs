using CashFlow.Application.ViewModels;

namespace CashFlow.Application.Interfaces
{
    public interface IDebitService
    {
        void AddDebit(FlowViewModel flowViewModel);
    }
}
