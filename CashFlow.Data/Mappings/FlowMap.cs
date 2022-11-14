using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlow.Data.Mappings
{
    public class FlowMap : IEntityTypeConfiguration<Flow>
    {
        public void Configure(EntityTypeBuilder<Flow> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Value).IsRequired();
        }
    }
}
