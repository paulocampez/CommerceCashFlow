using CommerceCashFlow.Core.Entities;
using System.Collections.Generic;

namespace CommerceCashFlow.Core.Services;
    public interface IMerchantService
    {
        Task<IEnumerable<Merchant>> GetAllMerchants();
        Task<Merchant> GetMerchantById(Guid id);
        Task CreateMerchant(Merchant merchant);
        Task UpdateMerchant(Merchant merchant);
        Task DeleteMerchant(Guid id);
    }