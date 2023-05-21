using CommerceCashFlow.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceCashFlow.Core.Services.Interfaces
{
    public interface IReportService
    {
        Task<Report> GetReportAsync(Guid merchantId, int day, int month, int year);
    }
}
