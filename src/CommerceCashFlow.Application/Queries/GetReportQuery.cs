using MediatR;
using CommerceCashFlow.Application.Models;

namespace CommerceCashFlow.Application.Queries
{
    public class GetReportQuery : IRequest<ReportViewModel>
    {
        public Guid MerchantId { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public GetReportQuery(Guid merchantId, int day, int month, int year)
        {
            MerchantId = merchantId;
            Day = day;
            Month = month;
            Year = year;
        }
    }
}