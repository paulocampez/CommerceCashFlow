using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CommerceCashFlow.Application.Queries;
using CommerceCashFlow.Application.Models;
using CommerceCashFlow.Core.Entities;
using CommerceCashFlow.Core.Repositories;
using MediatR;

namespace CommerceCashFlow.Application.Queries
{
    public class GetMerchantQueryHandler : IRequestHandler<GetMerchantQuery, MerchantViewModel>
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMapper _mapper;

        public GetMerchantQueryHandler(IMerchantRepository merchantRepository, IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
        }

        public async Task<MerchantViewModel> Handle(GetMerchantQuery request, CancellationToken cancellationToken)
        {
            var merchants = await _merchantRepository.GetMerchantById(request.MerchantId);
            var merchantViewModel  = _mapper.Map<MerchantViewModel>(merchants);
            return merchantViewModel;
        }
        
    }

}
