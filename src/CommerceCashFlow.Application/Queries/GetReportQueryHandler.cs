using MediatR;
using CommerceCashFlow.Application.Models;
using AutoMapper;
using CommerceCashFlow.Core.Repositories.Interfaces;
using CommerceCashFlow.Core.Services.Interfaces;

namespace CommerceCashFlow.Application.Queries;

public class GetReportQueryHandler : IRequestHandler<GetReportQuery, ReportViewModel>
{
    private readonly IMapper _mapper;
    private readonly IReportRepository _reportRepository;
    private readonly IReportService _reportService;
    public GetReportQueryHandler(IReportService reportService, IReportRepository reportRepository, IMapper mapper)
    {
        _mapper = mapper;
        _reportRepository = reportRepository;
        _reportService = reportService;
    }
    public async Task<ReportViewModel> Handle(GetReportQuery request, CancellationToken cancellationToken)
    {
        var report = await _reportService.GetReportAsync(request.MerchantId, request.Day, request.Month, request.Year);
        if (report == null)
        {
            throw new ArgumentException();
        }
        var reportViewModel = _mapper.Map<ReportViewModel>(report);
        return reportViewModel;
    }
}
