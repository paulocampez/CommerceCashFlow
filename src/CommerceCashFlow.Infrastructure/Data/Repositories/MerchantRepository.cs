using CommerceCashFlow.Core.Entities;
using CommerceCashFlow.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CommerceCashFlow.Infrastructure.Data.Repositories;

    public class MerchantRepository : IMerchantRepository
    {
            private readonly CommerceCashFlowContext _context;

        public MerchantRepository(CommerceCashFlowContext context)
        {
            _context = context;
        }

        public async Task<Merchant> GetMerchantById(Guid id)
        {
            return await _context.Merchants.FindAsync(id);
        }

        public async Task<IEnumerable<Merchant>> GetAllMerchants()
        {
            return await Task.FromResult(_context.Merchants.ToList());
        }

        public async Task AddMerchant(Merchant merchant)
        {
            await _context.Merchants.AddAsync(merchant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMerchant(Merchant merchant)
        {
            _context.Merchants.Update(merchant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMerchant(Guid id)
        {
            var merchant = await GetMerchantById(id);
            if (merchant != null)
            {
                _context.Merchants.Remove(merchant);
                await _context.SaveChangesAsync();
            }
        }
    }

