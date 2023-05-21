using CommerceCashFlow.Core.Entities;

namespace CommerceCashFlow.Application.Models;
public class TransactionsViewModel
{
    public DateTime Date { get; set; }
    public double Amount { get; set; }
    public TransactionCategory TransactionCategory { get; set; }
}