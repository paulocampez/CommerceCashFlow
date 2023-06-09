﻿using CommerceCashFlow.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceCashFlow.Core.Repositories.Caching
{
    public interface IReportCache
    {
        Task<Report> GetReportAsync(string reportId);
        Task SetReportAsync(string reportId, Report report);
    }
}
