using CashFlow.Domain.Models;

namespace CashFlow.Domain.Entities
{
    public class Flow : Entity
    {
        public double Value { get; set; }
        public string FlowType { get; set; }
    }
}
