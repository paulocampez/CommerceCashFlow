using MediatR;
using CommerceCashFlow.Application.Models;

namespace CommerceCashFlow.Application.Queries
{
    public class GetMerchantQuery : IRequest<MerchantViewModel>
    {
        public Guid MerchantId { get; set; }
        public GetMerchantQuery(Guid id)
        {
            MerchantId = id;
        }
    }
}