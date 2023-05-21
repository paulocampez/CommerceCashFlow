using CommerceCashFlow.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommerceCashFlow.Infrastructure.Data
{
    public class CommerceCashFlowContext : DbContext
    {
        public CommerceCashFlowContext(DbContextOptions<CommerceCashFlowContext> options) : base(options)
        {
        }

        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        // public DbSet<TransactionCategory> TransactionCategories { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity configurations, relationships, and other constraints here
            // Example:
            // modelBuilder.ApplyConfiguration(new MerchantConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}