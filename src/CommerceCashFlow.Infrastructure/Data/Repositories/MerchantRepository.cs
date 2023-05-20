using CommerceCashFlow.Core.Entities;
using CommerceCashFlow.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CommerceCashFlow.Infrastructure.Data.Repositories;

    public class MerchantRepository : IMerchantRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MerchantRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Merchant> GetAllMerchants()
        {
            return _dbContext.Merchants.ToList();
        }

        public Merchant GetMerchantById(int id)
        {
            return _dbContext.Merchants.FirstOrDefault(m => m.Id == id);
        }

        public Merchant CreateMerchant(Merchant merchant)
        {
            _dbContext.Merchants.Add(merchant);
            _dbContext.SaveChanges();
            return merchant;
        }

        public Merchant UpdateMerchant(Merchant merchant)
        {
            _dbContext.Entry(merchant).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return merchant;
        }

        public bool DeleteMerchant(int id)
        {
            var merchant = _dbContext.Merchants.FirstOrDefault(m => m.Id == id);
            if (merchant != null)
            {
                _dbContext.Merchants.Remove(merchant);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }

