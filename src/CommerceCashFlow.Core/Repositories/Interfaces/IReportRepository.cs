using CommerceCashFlow.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceCashFlow.Core.Repositories.Interfaces
{
    public interface IReportRepository
    {
        Task<Report> GetReportAsync(string reportId);
    }
}
