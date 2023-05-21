using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CommerceCashFlow.Application.Queries;
using CommerceCashFlow.Application.Models;
using CommerceCashFlow.Core.Entities;
using CommerceCashFlow.Core.Repositories;
using MediatR;
using CommerceCashFlow.Core.Repositories.Interfaces;

namespace CommerceCashFlow.Application.Queries
{
    public class GetTransactionsQueryHandler : IRequestHandler<GetTransactionsQuery, List<TransactionsViewModel>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionsQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<List<TransactionsViewModel>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _transactionRepository.GetTransactionsByMerchantIdAsync(request.MerchantId);
            var transactionsViewModel = _mapper.Map<List<TransactionsViewModel>>(transactions);
            return transactionsViewModel;
        }
        
    }

}
