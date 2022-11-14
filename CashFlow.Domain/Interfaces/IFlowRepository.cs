
using CashFlow.Domain.Entities;
using System.Collections.Generic;

namespace CashFlow.Domain.Interfaces
{
    public interface IFlowRepository : IRepository<Flow>
    {
        IEnumerable<Flow> GetAll();

    }
}
