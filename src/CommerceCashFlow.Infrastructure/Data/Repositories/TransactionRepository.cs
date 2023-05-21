using CommerceCashFlow.Core.Entities;
using CommerceCashFlow.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceCashFlow.Infrastructure.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly CommerceCashFlowContext _context;

        public TransactionRepository(CommerceCashFlowContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction.Id;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByMerchantIdAsync(Guid merchantId)
        {
            return await _context.Transactions
                .Where(t => t.MerchantId == merchantId)
                .ToListAsync();
        }
    }
}
