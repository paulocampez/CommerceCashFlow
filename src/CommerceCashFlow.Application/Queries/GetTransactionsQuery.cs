using MediatR;
using CommerceCashFlow.Application.Models;

namespace CommerceCashFlow.Application.Queries
{
    public class GetTransactionsQuery : IRequest<List<TransactionsViewModel>>
    {
        public Guid MerchantId { get; set; }
        public GetTransactionsQuery(Guid id)
        {
            MerchantId = id;
        }
    }
}