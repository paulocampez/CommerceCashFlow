using CommerceCashFlow.Core.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceCashFlow.Core.Repositories.Caching
{
    public class ReportCache : IReportCache
    {
        private readonly IDistributedCache _cache;

        public ReportCache(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<Report> GetReportAsync(string reportId)
        {
            var cachedReport = await _cache.GetAsync(reportId);
            if (cachedReport != null)
            {
                var serializedReport = Encoding.UTF8.GetString(cachedReport);
                return JsonConvert.DeserializeObject<Report>(serializedReport);
            }
            return null;
        }

        public async Task SetReportAsync(string reportId, Report report)
        {
            var serializedReport = JsonConvert.SerializeObject(report);
            var cacheOptions = new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(10) // Set the cache expiration time
            };
            await _cache.SetAsync(reportId, Encoding.UTF8.GetBytes(serializedReport), cacheOptions);
        }
    }

}
