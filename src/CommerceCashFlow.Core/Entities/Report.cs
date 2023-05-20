using System;

namespace CommerceCashFlow.Core.Entities;
public class Report
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal OpeningBalance { get; set; }
    public decimal TotalCredit { get; set; }
    public decimal TotalDebit { get; set; }
    public decimal ClosingBalance { get; set; }
    public int MerchantId { get; set; }
    public Merchant Merchant { get; set; }
}