using CommerceCashFlow.Core.Entities;
using System.Collections.Generic;

namespace CommerceCashFlow.Core.Services;
    public interface IMerchantService
    {
        IEnumerable<Merchant> GetAllMerchants();
        Merchant GetMerchantById(int id);
        Merchant CreateMerchant(Merchant merchant);
        Merchant UpdateMerchant(Merchant merchant);
        bool DeleteMerchant(int id);
    }