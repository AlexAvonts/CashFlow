using CashFlow.Data.Context;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace CashFlow.Data.Repositories
{
    public class FlowRepository : Repository<Flow>, IFlowRepository
    {
        public FlowRepository(CashFlowContext context) 
            : base(context) { }

        public IEnumerable<Flow> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }
    }
}
