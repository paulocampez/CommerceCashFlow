using CommerceCashFlow.Core.Entities;
using System.Collections.Generic;

namespace CommerceCashFlow.Core.Repositories;

    public interface IMerchantRepository
    {
        IEnumerable<Merchant> GetAllMerchants();
        Merchant GetMerchantById(int id);
        Merchant CreateMerchant(Merchant merchant);
        Merchant UpdateMerchant(Merchant merchant);
        bool DeleteMerchant(int id);
    }
