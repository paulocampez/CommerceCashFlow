using System;

namespace CommerceCashFlow.Core.Entities;
public class Transaction
{
    public int Id { get; set; }
    public double Amount { get; set; }
    public Guid MerchantId { get; set; }
    public TransactionCategory TransactionCategory { get; set; }
    public DateTime Date { get; set; }
    public Merchant Merchant { get; set; }
}

public enum TransactionCategory //TODO: Send to enum folder
{
    Credit,
    Debit
}
