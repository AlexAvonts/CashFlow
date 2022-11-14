using CashFlow.Data.Extensions;
using CashFlow.Data.Mappings;
using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Data.Context
{
    public class CashFlowContext : DbContext
    {
        public CashFlowContext() { }
        public CashFlowContext(DbContextOptions<CashFlowContext> option)
            : base(option) { }

        public DbSet<Flow> Flows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlowMap());
            modelBuilder.ApplyGlobalConfigurations();

            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }
    }
}
