using Microsoft.EntityFrameworkCore;
using CommerceCashFlow.Core.Entities;

namespace CommerceCashFlow.Infrastructure.Data
{
    public class CommerceCashFlowContext : DbContext
    {
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public CommerceCashFlowContext(DbContextOptions<CommerceCashFlowContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommerceCashFlowContext).Assembly);
        }
    }
}
