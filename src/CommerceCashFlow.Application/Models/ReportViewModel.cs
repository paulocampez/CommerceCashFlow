namespace CommerceCashFlow.Application.Models;
public class ReportViewModel
{
    public Guid MerchantId { get; set; }
    public DateTime Date { get; set; }
    public double OpeningBalance { get; set; }
    public double TotalCredit { get; set; }
    public double TotalDebit { get; set; }
    public double ClosingBalance { get; set; }
}