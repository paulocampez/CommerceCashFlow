using CommerceCashFlow.Core.Entities;
using CommerceCashFlow.Core.Repositories.Caching;
using CommerceCashFlow.Core.Repositories.Interfaces;
using CommerceCashFlow.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceCashFlow.Infrastructure.Data.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly IReportCache _reportCache;
        private readonly CommerceCashFlowContext _dbContext;

        public ReportRepository(IReportCache reportCache, CommerceCashFlowContext dbContext)
        {
            _reportCache = reportCache;
            _dbContext = dbContext;
        }

        public async Task<Report> GetReportAsync(string reportId)
        {
            var cachedReport = await _reportCache.GetReportAsync(reportId);
            if (cachedReport != null)
            {
                return cachedReport;
            }

            var report = await _dbContext.Reports.FindAsync(reportId);
            if (report != null)
            {
                await _reportCache.SetReportAsync(reportId, report);
            }

            return report;
        }
    }
}
