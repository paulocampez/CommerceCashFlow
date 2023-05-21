using MediatR;
using CommerceCashFlow.Application.Models;
using AutoMapper;
using CommerceCashFlow.Core.Repositories.Interfaces;

namespace CommerceCashFlow.Application.Queries;

public class GetReportQueryHandler : IRequestHandler<GetReportQuery, ReportViewModel>
{
    private readonly IMapper _mapper;
    private readonly IReportRepository _reportRepository;
    public GetReportQueryHandler(IReportRepository reportRepository, IMapper mapper)
    {
        _mapper = mapper;
        _reportRepository = reportRepository;
    }
    public async Task<ReportViewModel> Handle(GetReportQuery request, CancellationToken cancellationToken)
    {
        var report = await _reportRepository.GetReportAsync(request.ReportId);
        if (report == null)
        {
            throw new ArgumentException();
        }
        var reportViewModel = _mapper.Map<ReportViewModel>(report);
        return reportViewModel;
    }
}
