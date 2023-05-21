using System;

namespace CommerceCashFlow.Core.Entities;
public class Report
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public double OpeningBalance { get; set; }
    public double TotalCredit { get; set; }
    public double TotalDebit { get; set; }
    public double ClosingBalance { get; set; }
    public Guid MerchantId { get; set; }
    public Merchant Merchant { get; set; }
}