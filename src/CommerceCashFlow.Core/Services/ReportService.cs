using CommerceCashFlow.Core.Entities;
using CommerceCashFlow.Core.Repositories.Interfaces;
using CommerceCashFlow.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceCashFlow.Core.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly ITransactionRepository _transactionRepository;

        public ReportService(IReportRepository reportRepository, ITransactionRepository transactionRepository)
        {
            _reportRepository = reportRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<Report> GetReportAsync(Guid merchantId, int day, int month, int year)
        {
            var reportDate = new DateTime(year, month, day);
            var report = await _reportRepository.GetReportByMerchantIdAndDateAsync(merchantId, reportDate);
            if (report == null)
            {
                return await GenerateReportAsync(merchantId, reportDate);
            }
            return report;
        }

        private async Task<Report> GenerateReportAsync(Guid merchantId, DateTime Date)
        {
            double OpeningBalance = 0;
            var merchantTransactions = await _transactionRepository.GetTransactionsByMerchantIdAsync(merchantId);
            var yesterday = Date.AddDays(-1);


            var lastReport = await _reportRepository.GetReportByMerchantIdAndDateAsync(merchantId, yesterday);

            if (lastReport != null)
                OpeningBalance = lastReport.ClosingBalance;

            var filteredTransactions = merchantTransactions.Where(x => x.Date.ToShortDateString().Equals(Date.ToShortDateString()));
            double TotalCredit = merchantTransactions.Where(x => x.TransactionCategory == TransactionCategory.Credit).ToList().Sum(x => x.Amount);
            double TotalDebit = merchantTransactions.Where(x => x.TransactionCategory == TransactionCategory.Debit).ToList().Sum(x => x.Amount);
            double ClosingBalance = TotalCredit - TotalDebit;


            var report = new Report()
            {
                MerchantId = merchantId,
                Date = Date,
                ClosingBalance = ClosingBalance,
                OpeningBalance = OpeningBalance,
                TotalCredit = TotalCredit,
                TotalDebit = TotalDebit
            };
            return await _reportRepository.CreateAsync(report);
        }
    }
}
