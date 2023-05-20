using CommerceCashFlow.Core.Entities;
using System.Collections.Generic;

namespace CommerceCashFlow.Core.Repositories;

    public interface IMerchantRepository
    {
      Task<Merchant> GetMerchantById(Guid id);
        Task<IEnumerable<Merchant>> GetAllMerchants();
        Task AddMerchant(Merchant merchant);
        Task UpdateMerchant(Merchant merchant);
        Task DeleteMerchant(Guid id);
    }
