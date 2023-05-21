using MediatR;
using CommerceCashFlow.Application.Models;

namespace CommerceCashFlow.Application.Queries
{
    public class GetReportQuery : IRequest<ReportViewModel>
    {
        public string ReportId { get; set; }
        public GetReportQuery(string id)
        {
            ReportId = id;
        }
    }
}