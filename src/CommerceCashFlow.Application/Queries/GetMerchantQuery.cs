using MediatR;
using CommerceCashFlow.Application.Models;

namespace CommerceCashFlow.Application.Queries
{
    public class GetMerchantQuery : IRequest<MerchantDto>
    {
        public int MerchantId { get; set; }

    }
}