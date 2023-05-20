using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommerceCashFlow.Core.Entities;
using CommerceCashFlow.Core.Repositories;
using CommerceCashFlow.Core.Services;

namespace CommerceCashFlow.Core.Services;
    public class MerchantService : IMerchantService
    {
        private readonly IMerchantRepository _merchantRepository;

        public MerchantService(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        public async Task<IEnumerable<Merchant>> GetAllMerchants()
        {
            return await _merchantRepository.GetAllMerchants();
        }

        public async Task<Merchant> GetMerchantById(Guid merchantId)
        {
            return await _merchantRepository.GetMerchantById(merchantId);
        }

        public async Task CreateMerchant(Merchant merchant)
        {
            await _merchantRepository.AddMerchant(merchant);
        }

        public async Task UpdateMerchant(Merchant merchant)
        {
            await _merchantRepository.UpdateMerchant(merchant);
        }

        public async Task DeleteMerchant(Guid merchantId)
        {
            await _merchantRepository.DeleteMerchant(merchantId);
        }

   
}
